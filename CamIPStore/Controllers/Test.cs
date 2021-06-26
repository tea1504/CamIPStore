using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamIPStore.WebApp.Controllers
{
    public class Test : Controller
    {
        private readonly IPShopDBContext _context;
        public Test(IPShopDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.TaiKhoan.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoan
                .Include(s => s.DsHoaDon)
                    .ThenInclude(a => a.DsChiTietHoaDon)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.IdTK == id);

            if (taiKhoan == null)
            {
                return NotFound();
            }

            return View(taiKhoan);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("TenTK","MatKhau","SDT","DiaChi","Email","HoTen","QuyenSD")]
        TaiKhoan taiKhoan)
        {
            taiKhoan.TrangThai = true;
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(taiKhoan);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    ViewBag.err = ModelState.Values.SelectMany(v => v.Errors);
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Đã xảy ra lỗi không thể lưu được");
            }
            return View(taiKhoan);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var taiKhoan = await _context.TaiKhoan.FirstOrDefaultAsync(t => t.IdTK == id);
            if (taiKhoan == null)
            {
                return NotFound();
            }
            return View(taiKhoan);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTaiKhoan(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var taikhoanUpdate = await _context.TaiKhoan.FirstOrDefaultAsync(t => t.IdTK == id);
            if (await TryUpdateModelAsync<TaiKhoan>(
                taikhoanUpdate,
                "",
                t => t.SDT, t=>t.DiaChi, t=>t.Email, t=>t.HoTen, t=>t.QuyenSD, t=>t.TrangThai))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(taikhoanUpdate);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var taiKhoan = _context.TaiKhoan.SingleOrDefault(tk => tk.IdTK == id);
            _context.TaiKhoan.Remove(taiKhoan);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ApiTest()
        {
            return Ok(await _context.NhaSanXuat.ToListAsync());
        }
    }
}
