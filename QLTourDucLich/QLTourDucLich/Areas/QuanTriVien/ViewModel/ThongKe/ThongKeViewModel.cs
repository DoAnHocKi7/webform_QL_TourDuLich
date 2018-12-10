using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace QLTourDucLich.Areas.QuanTriVien.ViewModel.ThongKe
{
    [DataContract]
    public class ThongKeTheoTourViewModel
    {
        public int MaDiemDen { get; set; }

        [DataMember(Name ="label")]
        public string TenDiemDen { get; set; }

        [DataMember(Name = "y")]
        public decimal? TienDaBan { get; set; }
    }

}