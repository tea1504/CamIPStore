using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamIPStore.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private IPShopDBContext db;
        [Authorize(Roles = "1")]
        public async Task<IActionResult> Admin_account_list()
        {
            return View(await db.TaiKhoan.ToListAsync());
        }

        [HttpGet]
        [Authorize(Roles ="1")]
        public IActionResult Admin_account_create()
        {
            TaiKhoan Acc = new TaiKhoan();
            return View(Acc);
        }

        [HttpPost]
        [Authorize(Roles ="1")]
        public IActionResult Admin_account_create(TaiKhoan Acc)
        {
            TaiKhoan t = new TaiKhoan();
            t.TenTK = Acc.TenTK;
            t.MatKhau = Acc.MatKhau;
            t.SDT = Acc.SDT;
            t.DiaChi = Acc.DiaChi;
            t.Email = Acc.Email;
            t.HoTen = Acc.HoTen;
            t.QuyenSD = Acc.QuyenSD;
            t.TrangThai = true;
            db.TaiKhoan.Add(t);
            db.SaveChanges();
            return RedirectToAction("Admin_account_list");
        }

    }
}
