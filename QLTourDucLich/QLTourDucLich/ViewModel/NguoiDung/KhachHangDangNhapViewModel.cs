using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLTourDucLich.ViewModel.NguoiDung
{
    public class KhachHangDangNhapViewModel
    {
        [Display(Name = "Tên đăng nhập:")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        [MinLength(11, ErrorMessage = "Số Điện Thoại 11 ký tự")]
        public string TenDangNhap { get; set; }

        [Display(Name = "Mật Khẩu:")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        [MinLength(6, ErrorMessage = "Mật ít nhất phải 6 ký tự")]
        public string MatKhau { get; set; }
    }
}