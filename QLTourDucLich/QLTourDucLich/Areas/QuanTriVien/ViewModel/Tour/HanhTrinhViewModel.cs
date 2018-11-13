using QLTourDucLich.Areas.QuanTriVien.Queries.TourDuLich;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTourDucLich.Areas.QuanTriVien.ViewModel.Tour
{
    public class HanhTrinhViewModel
    {
        [Required]
        public int MaNoiDi { get; set; }

        [Required]
        public int MaNoiDen { get; set; }

        public SelectList DiaDiem { get; set; }

        public HanhTrinhViewModel()
        {
            DiaDiem = DiaDiemQueries.LoadDiaDiem();
        }
    }
}
