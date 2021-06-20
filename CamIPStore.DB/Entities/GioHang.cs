using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
   
    public class GioHang
    {
        public int IdCam { get; set; }
        public Camera Camera { get; set; }
        public int IdTK { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        public int Sl { get; set; }
    }
}
