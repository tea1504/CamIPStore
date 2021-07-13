using Entities;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CamIPStore.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KhuyenMaiController : Controller
    {
        private readonly IPShopDBContext _context;
        public KhuyenMaiController(IPShopDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _context.KhuyenMai.ToListAsync();
            return View(list);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var khuyenMai = await _context
                                    .KhuyenMai
                                    .SingleOrDefaultAsync(km => km.IdKM == id);
            ViewBag.dsCam = await _context
                                    .Cameras
                                    .Join(
                                        _context.ChiTietKhuyenMai,
                                        c => c.IdCam,
                                        km => km.IdCam,
                                        (c, km) => new { c, km.IdKM, km.KhuyenMai.PhanTramGiam }
                                    )
                                    .Where(c => c.IdKM == id)
                                    .ToListAsync();
            if (khuyenMai == null)
            {
                return NotFound();
            }
            return View(khuyenMai);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.listCam = await _context
                .Cameras
                .Join(
                    _context.Hinh,
                    c => c.IdCam,
                    h => h.IdCam,
                    (cam, img) => new { cam.Ten, cam.IdCam, img.Link, img.HinhDaiDien}
                )
                .Where(c => c.HinhDaiDien == true)
                .ToListAsync();
            ViewBag.Camera = await _context
                                    .Cameras
                                    .Select(c => new SelectListItem() { Text = c.IdCam + " | " + c.Ten, Value = c.IdCam.ToString()})
                                    .ToListAsync();
            return View();
        }
        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> Create(KhuyenMai khuyenMai, List<string> listIDKM, IFormFile Banner)
        {
            if(Banner == null)
            {
                ViewBag.listCam = await _context
                .Cameras
                .Join(
                    _context.Hinh,
                    c => c.IdCam,
                    h => h.IdCam,
                    (cam, img) => new { cam.Ten, cam.IdCam, img.Link, img.HinhDaiDien }
                )
                .Where(c => c.HinhDaiDien == true)
                .ToListAsync();
                ViewBag.Camera = await _context
                                        .Cameras
                                        .Select(c => new SelectListItem() { Text = c.IdCam + " | " + c.Ten, Value = c.IdCam.ToString() })
                                        .ToListAsync();
                ViewBag.BannerErr = "Bạn chưa chọn banner";
                ViewBag.listIDKM = listIDKM;
                return View("Create", khuyenMai);
            }
            if(listIDKM.Count == 0)
            {
                ViewBag.listCam = await _context
                .Cameras
                .Join(
                    _context.Hinh,
                    c => c.IdCam,
                    h => h.IdCam,
                    (cam, img) => new { cam.Ten, cam.IdCam, img.Link, img.HinhDaiDien }
                )
                .Where(c => c.HinhDaiDien == true)
                .ToListAsync();
                ViewBag.Camera = await _context
                                        .Cameras
                                        .Select(c => new SelectListItem() { Text = c.IdCam + " | " + c.Ten, Value = c.IdCam.ToString() })
                                        .ToListAsync();
                ViewBag.ListErr = "Bạn chưa chọn sản phẩm";
                return View("Create", khuyenMai);
            }
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/Images/Banner",
                Banner.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await Banner.CopyToAsync(stream);
            }
            khuyenMai.Banner = "/Images/Banner/" + Banner.FileName;
            _context.KhuyenMai.Add(khuyenMai);
            var create = _context.SaveChanges();
            List<ChiTietKhuyenMai> chiTietKhuyenMais = new List<ChiTietKhuyenMai>();
            foreach(var item in listIDKM)
            {
                ChiTietKhuyenMai chiTietKhuyenMai = new ChiTietKhuyenMai() { IdKM = khuyenMai.IdKM, IdCam = Int16.Parse(item) };
                chiTietKhuyenMais.Add(chiTietKhuyenMai);
            }
            _context.ChiTietKhuyenMai.AddRange(chiTietKhuyenMais);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var khuyenMai = await _context.KhuyenMai.SingleOrDefaultAsync(km => km.IdKM == id);
            if(khuyenMai == null)
            {
                return NotFound();
            }
            ViewBag.listCam = await _context
                .Cameras
                .Join(
                    _context.Hinh,
                    c => c.IdCam,
                    h => h.IdCam,
                    (cam, img) => new { cam.Ten, cam.IdCam, img.Link, img.HinhDaiDien }
                )
                .Where(c => c.HinhDaiDien == true)
                .ToListAsync();
            ViewBag.Camera = await _context
                                    .Cameras
                                    .Select(c => new SelectListItem() { Text = c.IdCam + " | " + c.Ten, Value = c.IdCam.ToString() })
                                    .ToListAsync();
            var listIDKM = await _context
                .ChiTietKhuyenMai
                .Where(ctkm => ctkm.IdKM == id)
                .Select(ctkm => ctkm.IdCam)
                .ToListAsync();
            ViewBag.listIDKM = listIDKM;
            return View(khuyenMai);
        }
        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edit(int id, List<string> listIDKM, IFormFile Banner)
        {
            var khuyenMai = await _context.KhuyenMai.SingleOrDefaultAsync(km => km.IdKM == id);
            if(listIDKM.Count == 0)
            {
                ViewBag.listCam = await _context
                .Cameras
                .Join(
                    _context.Hinh,
                    c => c.IdCam,
                    h => h.IdCam,
                    (cam, img) => new { cam.Ten, cam.IdCam, img.Link, img.HinhDaiDien }
                )
                .Where(c => c.HinhDaiDien == true)
                .ToListAsync();
                ViewBag.Camera = await _context
                                        .Cameras
                                        .Select(c => new SelectListItem() { Text = c.IdCam + " | " + c.Ten, Value = c.IdCam.ToString() })
                                        .ToListAsync();
                ViewBag.ListErr = "Bạn chưa chọn sản phẩm";
                return View("Edit", khuyenMai);
            }
            if (await TryUpdateModelAsync<KhuyenMai>(
                khuyenMai,
                "",
                km => km.TenKM, km => km.PhanTramGiam, km => km.TuNgay, km => km.DenNgay))
            {
                try
                {
                    if (Banner != null)
                    {
                        var path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot",
                            khuyenMai.Banner.Substring(1));
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot/Images/Banner",
                            Banner.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await Banner.CopyToAsync(stream);
                        }
                        khuyenMai.Banner = "/Images/Banner/" + Banner.FileName;
                    }
                    _context.KhuyenMai.Update(khuyenMai);
                    var listIDKM_old = await _context.ChiTietKhuyenMai.Where(ctkm => ctkm.IdKM == id).ToListAsync();
                    _context.ChiTietKhuyenMai.RemoveRange(listIDKM_old);
                    var listCTKM = new List<ChiTietKhuyenMai>();
                    foreach(var item in listIDKM)
                    {
                        var CTKM = new ChiTietKhuyenMai() { IdKM = khuyenMai.IdKM, IdCam = Int16.Parse(item) };
                        listCTKM.Add(CTKM);
                    }
                    _context.ChiTietKhuyenMai.AddRange(listCTKM);
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
            else
            {
                try
                {
                    if (Banner != null)
                    {
                        if (khuyenMai.Banner != null && khuyenMai.Banner != "")
                        {
                            var path = Path.Combine(
                                Directory.GetCurrentDirectory(),
                                "wwwroot",
                                khuyenMai.Banner.Substring(1));
                            if (System.IO.File.Exists(path))
                            {
                                System.IO.File.Delete(path);
                            }
                        }
                        var path2 = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot/Images/Banner",
                            Banner.FileName);
                        using (var stream = new FileStream(path2, FileMode.Create))
                        {
                            await Banner.CopyToAsync(stream);
                        }
                        khuyenMai.Banner = "/Images/Banner/" + Banner.FileName;
                    }
                    _context.KhuyenMai.Update(khuyenMai);
                    var listIDKM_old = await _context.ChiTietKhuyenMai.Where(ctkm => ctkm.IdKM == id).ToListAsync();
                    _context.ChiTietKhuyenMai.RemoveRange(listIDKM_old);
                    var listCTKM = new List<ChiTietKhuyenMai>();
                    foreach (var item in listIDKM)
                    {
                        var CTKM = new ChiTietKhuyenMai() { IdKM = khuyenMai.IdKM, IdCam = Int16.Parse(item) };
                        listCTKM.Add(CTKM);
                    }
                    _context.ChiTietKhuyenMai.AddRange(listCTKM);
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
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            KhuyenMai khuyenMai = await _context.KhuyenMai.SingleOrDefaultAsync(km => km.IdKM == id);
            if(khuyenMai == null){
                return NotFound();
            }
            var listCTKM = await _context.ChiTietKhuyenMai.Where(ctkm => ctkm.IdKM == id).ToListAsync();
            _context.ChiTietKhuyenMai.RemoveRange(listCTKM);
            await _context.SaveChangesAsync();
            var path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot",
                            khuyenMai.Banner.Substring(1));
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.KhuyenMai.Remove(khuyenMai);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
