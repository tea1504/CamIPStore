using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamIPStore.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IPShopDBContext _db;
        public AccountController(IPShopDBContext dbContext)
        {
            _db = dbContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            TaiKhoan i = new TaiKhoan();
            return View(i);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("TenTK, MatKhau")] TaiKhoan model)
        {
            if (ModelState.IsValid)
            {
                if ((_db.TaiKhoan.Any(s => s.TenTK == model.TenTK)) && (_db.TaiKhoan.Any(s => s.MatKhau == model.MatKhau)))
                {
                    HttpContext.Session.SetString("UserName", model.TenTK);
                    var taiKhoan = _db.TaiKhoan.FirstOrDefault(s => s.TenTK == model.TenTK);
                    HttpContext.Session.SetInt32("UserID", taiKhoan.IdTK);
                    if (_db.TaiKhoan.FirstOrDefault(s=>s.TenTK == model.TenTK).QuyenSD == false)
                            return RedirectToAction("Index", "Home");
                    
                    else return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc Password không đúng!");
                }
            }
            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
