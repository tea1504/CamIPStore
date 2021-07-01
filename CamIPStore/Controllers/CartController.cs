using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamIPStore.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IPShopDBContext _context;
        public CartController(IPShopDBContext context)
        {
            _context = context;
        }
        public IActionResult GetCartDetail(int id)
        {
            var list = _context
                .GioHang
                .Where(gh => gh.IdTK == id)
                .Include(gh => gh.Camera)
                .ThenInclude(c => c.DsHinh)
                .ToList();
            return PartialView("_CartDetail", list);
        }
        [HttpPost]
        public async Task<int> AddCart(GioHang gioHang)
        {
            var find = _context
                .GioHang
                .Where(gh => gh.IdTK == gioHang.IdTK && gh.IdCam == gioHang.IdCam)
                .SingleOrDefault();
            if (find == null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _context.GioHang.Add(gioHang);
                        _context.SaveChanges();
                    }
                    else
                        ViewBag.err = ModelState.Values.SelectMany(v => v.Errors);
                }
                catch (DbUpdateException /* ex */)
                {
                    return 0;
                }
            }
            else
            {
                find.Sl+=gioHang.Sl;
                _context.GioHang.Update(find);
                _context.SaveChanges();
            }
            return 1;
        }
        [HttpPost]
        public int DeteleCartItem(int IdTK, int IdCam)
        {
            var cart = _context.GioHang.SingleOrDefault(gh => gh.IdCam == IdCam && gh.IdTK == IdTK);
            if(cart != null)
            {
                _context.GioHang.Remove(cart);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
