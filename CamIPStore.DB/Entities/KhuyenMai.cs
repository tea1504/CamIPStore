using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{

    public class KhuyenMai
    {
        [Key]
        [Display(Name = "Mã khuyến mãi")]
        public int IdKM { get; set; }
        [Display(Name = "Tên khuyến mãi")]
        [Required(ErrorMessage = "Bạn phải nhập tên khuyến mãi")]
        public string TenKM { get; set; }
        [Display(Name = "Phần trăm giảm")]
        [Required(ErrorMessage = "Bạn phải nhập phần trăm giảm")]
        public int PhanTramGiam { get; set; }
        [Display(Name = "Ngày bắt đầu")]
        [Required(ErrorMessage = "Bạn phải chọn ngày bắt đầu")]
        public DateTime TuNgay { get; set; }
        [Display(Name = "Ngày kết thúc")]
        [Required(ErrorMessage = "Bạn phải chọn ngày kết thúc")]
        public DateTime DenNgay { get; set; }
        [Display(Name = "Banner")]
        [Required(ErrorMessage = "Bạn phải nhập banner khuyến mãi")]
        public string Banner { get; set; }
        public List<ChiTietKhuyenMai> DsChiTietKhuyenMai { get; set; }
    }
}
