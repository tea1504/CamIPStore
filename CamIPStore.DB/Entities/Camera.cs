using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    
    public class Camera
    {
        public int IdCam { get; set; }
        public int IdNSX { get; set; }
        public string Ten { get; set; }
        public string XuatXu { get; set; }
        public string CamBien { get; set; }
        public string AmThanh { get; set; }
        public string DoPhanGiai { get; set; }
        public string DungLuong { get; set; }
        public string KhoangCach { get; set; }
        public int DoXoayNgang { get; set; }
        public int DoXoayDoc { get; set; }
        public int SoLuong { get; set; }
        public bool KhongDay { get; set; }
        public bool CoDay { get; set; }
        public bool DKTuXa { get; set; }
        public float GiaGoc { get; set; }
        public float GiaBan { get; set; }
        public string MoTa { get; set; }
        public List<GioHang> DsGioHang { get; set; }
        public List<ChiTietKhuyenMai> DsChiTietKhuyenMai { get; set; }
        public List<ChiTietHoaDon> DsChiTietHoaDon { get; set; }
        public List<Hinh> DsHinh { get; set; }
        public NhaSanXuat NhaSanXuat { get; set; }
    }
}
