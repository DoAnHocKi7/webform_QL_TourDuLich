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

        public int sltreem { get; set; }
        public float dgtreem;      
       
        public int slnguoilon { get; set; }
        public float dgnguoilon;
        public int soluong;
        public float thanhtien
        {
            get
            {
                return dongia += dongia; 

            }
        }
        public SPDaMua(string masp)
        {
            matour = masp;
            TOUR tour = ql.TOURs.Single(t => t.MaTour == masp);

            KHACHSAN khachsan = ql.KHACHSANs.Single(t => t.MaKS == tour.MaKS);
            tentour = tour.TenTour;
            hinhanh = tour.AnhDaiDien;
            slnguoilon = 1;
            sltreem = 1;

            dgnguoilon = float.Parse(tour.GiaNguoiLon.ToString());
            dgtreem = float.Parse(tour.GiaNguoiLon.ToString());

            dongia = dgnguoilon * slnguoilon+dgtreem*sltreem+float.Parse(khachsan.GiaTien.ToString());
            soluong = 1;
            //dongia = float.Parse( tour.GiaTour.ToString());
          //  dongia = float.Parse((tour.GiaNguoiLon + tour.GiaTreEm+khachsan.GiaTien).ToString());

           


        }
    }
}