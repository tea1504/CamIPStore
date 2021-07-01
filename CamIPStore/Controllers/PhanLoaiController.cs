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
                return View(_context.Cameras.Include(c => c.DsHinh).ToList());
            }
            var list = _context.Cameras.Where(c => c.IdNSX == id).Include(c => c.DsHinh).ToList();
            return View(list);
        }
        public IActionResult GetPartial(int id)
        {
            var cam = _context.Cameras.Include(c => c.DsHinh).SingleOrDefault(c => c.IdCam == id);
            return PartialView("_Model", cam);
        }
    }
}
