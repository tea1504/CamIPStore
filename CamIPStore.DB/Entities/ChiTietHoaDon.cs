using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
 
    public class ChiTietHoaDon
    {
        public int IdCam { get; set; }
        public Camera Camera { get; set; }
        public int IdHD { get; set; }
        public HoaDon HoaDon { get; set; }
        public int SLMua { get; set; }
        public float GiaBan { get; set; }
    }
}
