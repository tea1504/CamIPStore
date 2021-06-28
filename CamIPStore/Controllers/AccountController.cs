using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return View();
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
