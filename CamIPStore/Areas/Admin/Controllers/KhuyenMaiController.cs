using Entities;
using Microsoft.AspNetCore.Mvc;
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
                                    .Include(km => km.DsChiTietKhuyenMai)
                                    .ThenInclude(ds => ds.Camera)
                                    .Where(km => km.IdKM == id)
                                    .SingleOrDefaultAsync();
            if (khuyenMai == null)
            {
                return NotFound();
            }
            return View(khuyenMai);
        }
    }
}
