using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{

    public class KhuyenMai
    {
        public int IdKM { get; set; }
        public string TenKM { get; set; }
        public int PhanTramGiam { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public List<ChiTietKhuyenMai> DsChiTietKhuyenMai { get; set; }
    }
}
