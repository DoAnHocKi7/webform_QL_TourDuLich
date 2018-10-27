using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLTourDucLich.Areas.QuanTriVien.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Bắt buộc nhập {0}")]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }
    }
}