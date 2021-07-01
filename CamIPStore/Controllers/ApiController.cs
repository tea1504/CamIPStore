using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace CamIPStore.WebApp.Controllers
{
    public class ApiController : Controller
    {
        private readonly IPShopDBContext _context;
        public ApiController(IPShopDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> NhaSanXuat()
        {
            var list = await _context.NhaSanXuat.ToListAsync();
            return Ok(list);
        }

        public IActionResult KhuyenMai()
        {
            var compareDate = DateTime.Now;
            var list =  _context.KhuyenMai.Where(km => km.DenNgay >= compareDate).ToList();
            return Ok(list);
        }

        public IActionResult getCamera(int id)
        {
            var camera = _context
                .Cameras
                .Include(c => c.DsHinh)
                .SingleOrDefault(c => c.IdCam == id);
            return Ok(camera);
        }
    }
}
