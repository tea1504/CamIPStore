using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    
    public class Hinh
    {
        public int IdHinh { get; set; }
        public int IdCam { get; set; }
        public Camera Camera { get; set; }
        public string Link { get; set; }
        public bool HinhDaiDien { get; set; }
    }
}
