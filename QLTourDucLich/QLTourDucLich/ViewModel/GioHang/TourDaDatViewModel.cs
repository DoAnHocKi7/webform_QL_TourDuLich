using QLTourDucLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTourDucLich.ViewModel.GioHang
{
    public class TourDaDatViewModel
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

        public DateTime? Ngaykh { get; set; }
        public DateTime? Ngaykt { get; set; }
        public string NoiDi { get; set; }
        public string NoiDen { get; set; }

        public TourDaDatViewModel(string masp)
        {
            //-----------------------------------------------------
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
            //----------------------------------------------
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            var res = (from t in entity.TOURs
                       where t.MaTour == masp
                       join ks in entity.KHACHSANs
                       on t.MaKS equals ks.MaKS
                       join ht in entity.HANHTRINHs
                       on t.MaHanhTrinh equals ht.MaHanhTrinh
                       join dd1 in entity.DIADIEMs
                       on ht.NoiDen equals dd1.MaDiaDiem
                       join dd2 in entity.DIADIEMs
                       on ht.NoiDi equals dd2.MaDiaDiem
                       select new
                       {
                           NoiBD = dd1.TenDiaDiem,
                           NoiKT = dd2.TenDiaDiem,
                           NgayDi=t.NgayKhoiHanh.Value,
                           NgayDen=t.NgayKetThuc.Value
                       });
            var kq = res.FirstOrDefault();
            NoiDi = kq.NoiBD;
            NoiDen = kq.NoiKT;
            Ngaykh = kq.NgayDi;
            Ngaykt = kq.NgayDen;

        }

        public TourDaDatViewModel()
        {
        }
    }
}