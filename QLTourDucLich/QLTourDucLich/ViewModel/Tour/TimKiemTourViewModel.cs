using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLTourDucLich.ViewModel.Tour
{
    public class TimKiemTourViewModel
    {
        [Required]
        public int? NoiDi { get; set; }

        [Required]
        public int? NoiDen { get; set; }

        [Required]
        public DateTime NgayDi { get; set; }

        //[Required]
        //public DateTime NgayDen { get; set; }
    }
}