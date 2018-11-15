using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLTourDucLich.ViewModel.NguoiDung
{
    public class ThongTinBoSungKhachHangViewModel
    {
        [Display(Name = "Tên khách hàng")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        public string TenKH { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        public string DiaChi { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        [MinLength(11, ErrorMessage = "Số Điện Thoại 11 ký tự")]
        public string Phone { get; set; }

    }
}