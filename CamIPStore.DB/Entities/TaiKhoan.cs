using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
  
    public class TaiKhoan
    {
        [Display(Name = "ID")]
        public int IdTK { get; set; }
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Tài khoản không được bỏ trống")]
        public string TenTK { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        public string MatKhau { get; set; }
        [Display(Name = "Số điện thoại")]
       //[Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        public string SDT { get; set; }
        [Display(Name = "Địa chỉ")]
        // [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        public string DiaChi { get; set; }
        [Display(Name = "Địa chỉ email")]
        // [Required(ErrorMessage = "Địa chỉ email không được bỏ trống")]
        public string Email { get; set; }
        [Display(Name = "Họ và tên")]
        // [Required(ErrorMessage = "Họ tên không được bỏ trống")]
        public string HoTen { get; set; }
        [Display(Name = "Quyền sử dụng")]
        public bool QuyenSD { get; set; }
        [Display(Name = "Trạng thái tài khoản")]
        public bool TrangThai { get; set; }
        public List<GioHang> DsGioHang { get; set; }
        public List<HoaDon> DsHoaDon { get; set; }
    }
}
