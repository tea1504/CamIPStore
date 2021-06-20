using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
  
    public class TaiKhoan
    {
        public int IdTK { get; set; }
        public string TenTK { get; set; }
        public string MatKhau { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string HoTen { get; set; }
        public bool QuyenSD { get; set; }
        public bool TrangThai { get; set; }
        public List<GioHang> DsGioHang { get; set; }
        public List<HoaDon> DsHoaDon { get; set; }
    }
}
