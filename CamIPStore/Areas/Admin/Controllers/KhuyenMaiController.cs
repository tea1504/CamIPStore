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
    }
}
