using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{   

    public class HoaDon
    {
        public int IdHD { get; set; }
        public int IdTK { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        public DateTime NgayTao { get; set; }
        public float TongGia { get; set; }
        public int BaoHanh { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayLap { get; set; }
        public int TrangThai { get; set; }
        public List<ChiTietHoaDon> DsChiTietHoaDon { get; set; }
    }
}
