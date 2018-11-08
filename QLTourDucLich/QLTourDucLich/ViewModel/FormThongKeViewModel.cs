using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLTourDucLich.ViewModel
{
    public class FormThongKeViewModel
    {
        [Required]
        public string Thang { get; set; }

        [Required]
        public string Nam { get; set; }
    }
}