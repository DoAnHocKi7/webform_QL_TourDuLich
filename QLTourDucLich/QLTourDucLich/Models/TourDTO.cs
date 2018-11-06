using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTourDucLich.Models
{
    public class TourDTO
    {
        QlTourDuLichEntities ql = new QlTourDuLichEntities();
        public string MaTour { get; set; }
        public string TenTour { get; set; }
        public DateTime? Ngaykh { get; set; }
        public DateTime? Ngaykt { get; set; }
        public string NoiDi { get; set; }
        public string NoiDen { get; set; }
        public string MaHanhTrinh { get; set; }
        public decimal? GiaTour { get; set; }
        public string AnhDaiDien { get; set; }
    }
}