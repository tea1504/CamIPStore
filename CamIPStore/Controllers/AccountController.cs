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
        //[Authorize(Roles = "1")]
        public async Task<IActionResult> Admin_account_list()
        {
            return View(await db.TaiKhoan.ToListAsync());
        }

        [HttpGet]
        //[Authorize(Roles ="1")]
        public IActionResult Admin_account_create()
        {
            TaiKhoan Acc = new TaiKhoan();
            return View(Acc);
        }

        [HttpPost]
        //[Authorize(Roles ="1")]
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

        [HttpGet]
        [Authorize(Roles ="1")]
        public IActionResult Admin_account_edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Admin_account_edit(TaiKhoan Acc)
        {
            TaiKhoan AccTemp = db.TaiKhoan.Where(a => a.IdTK == Acc.IdTK).FirstOrDefault();
            db.Entry(AccTemp).State = EntityState.Detached;
            TaiKhoan t = new TaiKhoan();
            t.TenTK = Acc.TenTK;
            t.MatKhau = Acc.MatKhau;
            t.SDT = Acc.SDT;
            t.DiaChi = Acc.DiaChi;
            t.Email = Acc.Email;
            t.HoTen = Acc.HoTen;
            t.QuyenSD = Acc.QuyenSD;
            t.TrangThai = true;
            db.Entry(t).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Admin_account_list");
        }

        public IActionResult Admin_account_ban(int IdTk)
        {
            TaiKhoan Acc = db.TaiKhoan.Where(a => a.IdTK == IdTk).FirstOrDefault();
            db.Entry(Acc).State = EntityState.Detached;
            TaiKhoan AccTemp = Acc;
            AccTemp.TrangThai = false;
            db.Entry(AccTemp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Admin_account_list");
        }
    }
}
