using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTourDucLich.Models
{
    public class ChiTietT
    {
        QlTourDuLichEntities ql = new QlTourDuLichEntities();
        public string matour { get; set; }
        public string tentour { get; set; }
        public DateTime? ngaykh{get;set;}
        public DateTime? ngaykt { get; set; }
        public string noidi { get; set; }
        public string noiden { get; set; }
        public string mahanhtrinh { get; set; }
        public decimal? giatour { get; set; }
        public string anhdaidien { get; set; }

        public ChiTietT(string masp)
        {
            TOUR tour = ql.TOURs.Single(t => t.MaTour == masp);
            matour = tour.MaTour;
            tentour = tour.TenTour;
            ngaykh = tour.NgayKhoiHanh;
            ngaykt = tour.NgayKetThuc;
            HANHTRINH ht = ql.HANHTRINHs.Single(a => a.MaHanhTrinh == tour.MaHanhTrinh);
            DIADIEM diadiemdi = ql.DIADIEMs.Single(d => d.MaDiaDiem == ht.NoiDi);
            DIADIEM diadiemden = ql.DIADIEMs.Single(d => d.MaDiaDiem == ht.NoiDen);
            noidi = diadiemdi.TenDiaDiem;
            noiden = diadiemden.TenDiaDiem;
            KHACHSAN khsan = ql.KHACHSANs.Single(ks => ks.MaKS == tour.MaKS);
            giatour = tour.GiaNguoiLon + khsan.GiaTien;
            anhdaidien = tour.AnhDaiDien;







        }
       

    }
}