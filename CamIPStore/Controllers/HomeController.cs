using CamIPStore.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CamIPStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPShopDBContext _context;

        public HomeController(ILogger<HomeController> logger, IPShopDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var compareDate = DateTime.Now;
            ViewBag.slider = _context.KhuyenMai.Where(km => km.DenNgay >= compareDate).ToList();
            ViewBag.banner = _context.NhaSanXuat.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> KhuyenMai(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var list = await _context.KhuyenMai
                .Include(km => km.DsChiTietKhuyenMai)
                .ThenInclude(ctkm => ctkm.Camera)
                .ThenInclude(c => c.DsHinh)
                .SingleOrDefaultAsync(km => km.IdKM == id);
            return View(list);
        }
    }
}
