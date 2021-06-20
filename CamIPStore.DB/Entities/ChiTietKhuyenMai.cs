using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    
    public class ChiTietKhuyenMai
    {
        public int IdCam { get; set; }
        public KhuyenMai KhuyenMai { get; set; }
        public int IdKM { get; set; }
        public Camera Camera { get; set; }
    }
}
