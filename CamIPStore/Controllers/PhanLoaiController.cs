using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamIPStore.WebApp.Controllers
{
    public class PhanLoaiController : Controller
    {
        private IPShopDBContext _context;
        public PhanLoaiController(IPShopDBContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var list = _context.Cameras.Where(c => c.IdNSX == id).ToList();
            return View(list);
        }

    }
}
