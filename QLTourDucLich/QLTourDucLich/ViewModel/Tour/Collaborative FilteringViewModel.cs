using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTourDucLich.ViewModel.Tour
{
    public class KhachHangXepHangTourViewModel
    {
        public string MaKH { get; set; }

        public int SoLanDat { get; set; }
    }

    public class TourKhachHangDatViewModel
    {
        public string MaTour { get; set; }

        public int? SoLanDat { get; set; }
    }
}