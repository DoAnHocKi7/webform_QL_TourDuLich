using QLTourDucLich.ViewModel.Tour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTourDucLich.ViewModel.GioHang
{
    public class ChiTietHopDongViewModel
    {
        public string MaTour { get; set; }

        public string DiemDi { get; set; }

        public string DiemDen { get; set; }

        public DateTime? NgayDi { get; set; }

        public DateTime? NgayDen { get; set; }

        public int? TreEm { get; set; }

        public int? NguoiLon { get; set; }

        public decimal? ThanhTien { get; set; }

    }
}