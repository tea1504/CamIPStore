using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamIPStore.WebApp.Areas.Admin
{
    [Area("Admin")]
    public class Home : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
    }
}
