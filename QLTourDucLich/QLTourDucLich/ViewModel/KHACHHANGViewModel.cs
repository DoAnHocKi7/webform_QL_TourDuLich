using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLTourDucLich.Models;
using System.ComponentModel.DataAnnotations;

namespace QLTourDucLich.ViewModel
{
    public class KHACHHANGViewModel
    {
        public string MaKH { get; set; }

        [Display(Name = "Tên Khách Hàng:")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        public string TenKH { get; set; }

        [Display(Name = "Ngày Sinh:")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NgaySinh { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Phone:")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        [MinLength(11, ErrorMessage = "Số Điện Thoại 11 ký tự")]
        public string Phone { get; set; }

        [Display(Name = "Mật Khẩu:")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        [MinLength(6, ErrorMessage = "Mật ít nhất phải 6 ký tự")]
        public string MatKhau { get; set; }
    }
}