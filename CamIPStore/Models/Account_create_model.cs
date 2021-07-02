using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CamIPStore.WebApp.Models
{
    public class Account_create_model
    {       
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Tài khoản không được bỏ trống")]
        public string TenTK { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        public string MatKhau { get; set; }
        [Display(Name = "Nhập lại mật khẩu")]
        [Required(ErrorMessage = "Xác nhận mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu không trùng khớp")]
        public string XacNhanMatKhau { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        public string SDT { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        public string DiaChi { get; set; }
        [Display(Name = "Địa chỉ email")]
        [Required(ErrorMessage = "Địa chỉ email không được bỏ trống")]
        public string Email { get; set; }
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ tên không được bỏ trống")]
        public string HoTen { get; set; }             
    }
}
