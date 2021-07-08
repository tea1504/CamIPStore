using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            ViewBag.Camera = await _context.Cameras.ToListAsync();
            return View();
        }
    }
}
