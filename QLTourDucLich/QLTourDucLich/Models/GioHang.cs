using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTourDucLich.Models
{
    public class GioHang
    {
        QlTourDuLichEntities1 ql = new QlTourDuLichEntities1();
        public string matour { get; set; }
        public string tentour { get; set; }
        public string hinhanh { get; set; }
        public float dongia { get; set; }
        public int soluong { get; set; }
        public float thanhtien
        {
            get
            {
                return soluong * dongia;
            }
        }
        public GioHang(string masp)
        {
            matour = masp;
            TOUR tour = ql.TOURs.Single(t => t.MaTour == masp);
            tentour = tour.TenTour;
            hinhanh = tour.AnhDaiDien;
            dongia = float.Parse( tour.GiaTour.ToString());
            soluong = 1;


        }
    }
}