using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace QLTourDucLich.Areas.QuanTriVien.ViewModel.ThongKe
{
    [DataContract]
    public class ThongKeTheoThoiGianViewModel
    {

        [DataMember(Name = "label")]
        public string TenTour { get; set; }

        [DataMember(Name = "legendText")]
        public string ChuThich { get; set; }

        [DataMember(Name = "y")]
        public decimal? TienDaBan { get; set; }

    }

    public class TourDaBanViewModel
    {
        public string NoiDi { get; set; }

        public string NoiDen { get; set; }

        public decimal? ThanhTien { get; set; }
    }
}