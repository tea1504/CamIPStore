using CamIPStore.WebApp.Models;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamIPStore.WebApp.Areas.Admin.Controllers
{
    public class AccountManagerController : Controller
    {
        private IPShopDBContext db;
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Admin_account_list()
        {
            return View(await db.TaiKhoan.ToListAsync());
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult Admin_account_create()
        {
            TaiKhoan Acc = new TaiKhoan();
            return View(Acc);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
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
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles ="Admin")]
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Customer_account_create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Customer_account_create(Account_create_model Acc)
        {
            TaiKhoan Acc_real = new TaiKhoan();
            Acc_real.DiaChi = Acc.DiaChi;
            Acc_real.SDT = Acc.SDT;
            Acc_real.QuyenSD = false;
            Acc_real.Email = Acc.Email;
            Acc_real.HoTen = Acc.HoTen;
            Acc_real.TenTK = Acc.TenTK;
            Acc_real.MatKhau = Acc.MatKhau;
            Acc_real.DiaChi = Acc.DiaChi;
            Acc_real.TrangThai = true;
            db.TaiKhoan.Add(Acc_real);
            db.SaveChanges();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [Authorize(Roles ="KhachHang")]
        public IActionResult Customer_account_info(int IdTK)
        {
            TaiKhoan Acc = db.TaiKhoan.Where(a => a.IdTK == IdTK).FirstOrDefault();
            return View(Acc);
        }
        [HttpGet]
        [Authorize(Roles = "KhachHang")]
        public IActionResult Customer_account_edit(int IdTK)
        {
            TaiKhoan Acc = db.TaiKhoan.Where(a => a.IdTK == IdTK).FirstOrDefault();
            return View(Acc);
        }
        [HttpPost]
        [Authorize(Roles ="KhachHang")]       
        public IActionResult Customer_account_edit(TaiKhoan Acc)
        {
            TaiKhoan Acc_pick = db.TaiKhoan.Where(a => a.IdTK == Acc.IdTK).FirstOrDefault();
            db.Entry(Acc_pick).State = EntityState.Detached;
            TaiKhoan Acc_real = new TaiKhoan();           
            Acc_real.IdTK = Acc.IdTK; // Readonly
            Acc_real.MatKhau = Acc.MatKhau; // Readonly
            Acc_real.TenTK = Acc.TenTK;
            Acc_real.DiaChi = Acc.DiaChi;
            Acc_real.Email = Acc.Email;
            Acc_real.SDT = Acc.SDT;
            Acc_real.HoTen = Acc.HoTen;
            Acc_real.QuyenSD = false;
            Acc_real.TrangThai = true;
            db.Entry(Acc_real).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }


    }
}
