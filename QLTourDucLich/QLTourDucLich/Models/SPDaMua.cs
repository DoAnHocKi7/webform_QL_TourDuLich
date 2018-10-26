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

        public decimal? dongia { get; set; }

        public int sltreem { get; set; }
        public decimal? giatreem;      
       
        public int slnguoilon { get; set; }
        public decimal gianguoilon;
        public int soluong;
        public decimal? thanhtien
        {
            get
            {
                return slnguoilon * dongia + sltreem * giatreem;


            }
        }
        public SPDaMua(string masp)
        {
            
            TOUR tour = ql.TOURs.Single(t => t.MaTour == masp);
            matour = tour.MaTour;
            tentour = tour.TenTour;
            hinhanh = tour.AnhDaiDien;
            giatreem = tour.GiaTreEm;
            KHACHSAN khachsan = ql.KHACHSANs.Single(t => t.MaKS == tour.MaKS);
            dongia = tour.GiaNguoiLon + khachsan.GiaTien;
            slnguoilon = 1;
            sltreem = 0;
            soluong = 1;
      

           


        }
    }
}