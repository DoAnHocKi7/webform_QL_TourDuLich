using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTourDucLich.Models
{
    public class SPDaMua
    {
        QlTourDuLichEntities ql = new QlTourDuLichEntities();
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
        public SPDaMua(string masp)
        {
            matour = masp;
            TOUR tour = ql.TOURs.Single(t => t.MaTour == masp);

            KHACHSAN khachsan = ql.KHACHSANs.Single(t => t.MaKS == tour.MaKS);
            tentour = tour.TenTour;
            hinhanh = tour.AnhDaiDien;
            //dongia = float.Parse( tour.GiaTour.ToString());
            dongia = float.Parse((tour.GiaNguoiLon + tour.GiaTreEm+khachsan.GiaTien).ToString());

            soluong = 1;


        }
    }
}