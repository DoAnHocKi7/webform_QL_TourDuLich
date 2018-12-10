using QLTourDucLich.Models;
using QLTourDucLich.ViewModel.GioHang;
using QLTourDucLich.ViewModel.Tour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTourDucLich.Queries.GioHang
{
    public class HopDongQueries
    {
        public static List<ChiTietHopDongViewModel> TimHopDong(string maHopDong)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            try
            {
                var result = (from hd in entity.HOPDONGs
                              where hd.MaHD == maHopDong
                              join ct in entity.ChiTietHopDongs
                              on hd.MaHD equals ct.MaHopDong
                              join t in entity.TOURs
                              on ct.MaTour equals t.MaTour
                              join ht in entity.HANHTRINHs
                              on t.MaHanhTrinh equals ht.MaHanhTrinh
                              join dden in entity.DIADIEMs
                              on ht.NoiDen equals dden.MaDiaDiem
                              join ddi in entity.DIADIEMs
                              on ht.NoiDi equals ddi.MaDiaDiem
                              //join kh in entity.KHACHHANGs
                              //on hd.MaKH equals kh.MaKH
                              select new ChiTietHopDongViewModel()
                              {
                                  MaTour = t.MaTour,
                                  DiemDi=ddi.TenDiaDiem,
                                  DiemDen=dden.TenDiaDiem,
                                  NgayDi=t.NgayKhoiHanh,
                                  NgayDen=t.NgayKetThuc,
                                  NguoiLon=ct.SLNguoiLon,
                                  TreEm=ct.SLTreEm,
                                  ThanhTien=ct.ThanhTien,
                              }).ToList();
                return result;
            }
            catch (Exception)
            {
                entity.Dispose();
            }
            return null;
        }
    }
}