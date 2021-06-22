using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    
    public class Camera
    {
        [Key]
        [Display(Name ="Mã camera")]
        public int IdCam { get; set; }
        [Required(ErrorMessage ="Bạn phải chọn nhà sản xuất")]
        [Display(Name ="Nhà sản xuất")]
        public int IdNSX { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tên camera")]
        [Display(Name = "Tên camera")]
        public string Ten { get; set; }
        [Display(Name = "Xuất xứ")]
        public string XuatXu { get; set; }
        [Display(Name = "Cảm biến")]
        public string CamBien { get; set; }
        [Display(Name = "Âm thanh")]
        public string AmThanh { get; set; }
        [Display(Name = "Độ phân giải")]
        public string DoPhanGiai { get; set; }
        [Display(Name = "Dung lượng bộ nhớ")]
        public string DungLuong { get; set; }
        [Display(Name = "Tầm nhìn")]
        public string KhoangCach { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập độ xoay ngang")]
        [Display(Name = "Độ xoay ngang")]
        public int DoXoayNgang { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập độ xoay dọc")]
        [Display(Name = "Đọ xoay dọc")]
        public int DoXoayDoc { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập số lượng")]
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }
        [Required(ErrorMessage = "Camera có phait loại không đây không")]
        [Display(Name = "Không dây")]
        public bool KhongDay { get; set; }
        [Required(ErrorMessage = "Camera có dây không")]
        [Display(Name = "Có dây")]
        public bool CoDay { get; set; }
        [Required(ErrorMessage = "Camera có được điều khiển từ xa không")]
        [Display(Name = "Điều khiển từ xa")]
        public bool DKTuXa { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập giá gốc")]
        [Display(Name = "Giá gốc")]
        public float GiaGoc { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập giá bán")]
        [Display(Name = "Giá bán")]
        public float GiaBan { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        public List<GioHang> DsGioHang { get; set; }
        public List<ChiTietKhuyenMai> DsChiTietKhuyenMai { get; set; }
        public List<ChiTietHoaDon> DsChiTietHoaDon { get; set; }
        public List<Hinh> DsHinh { get; set; }
        public NhaSanXuat NhaSanXuat { get; set; }
    }
}
