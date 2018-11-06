﻿using QLTourDucLich.Areas.QuanTriVien.ViewModel.ThongKe;
using QLTourDucLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace QLTourDucLich.Areas.QuanTriVien.Queries.Thong_Ke
{
    public class ThongKeQueries
    {
        public static List<ThongKeTheoTourViewModel> LayDuLieuThongKe()
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            try
            {
                var result = (from ct in entity.ChiTietHopDongs
                              join t in entity.TOURs
                              on ct.MaTour equals t.MaTour
                              join ht in entity.HANHTRINHs
                              on t.MaHanhTrinh equals ht.MaHanhTrinh
                              join dd in entity.DIADIEMs
                              on ht.NoiDen equals dd.MaDiaDiem
                              group new { dd, ct } by new { dd.TenDiaDiem, dd.MaDiaDiem } into grp
                              select new ThongKeTheoTourViewModel()
                              {
                                  TienDaBan = grp.Sum(t => t.ct.ThanhTien),
                                  MaDiemDen = grp.Key.MaDiaDiem,
                                  TenDiemDen = grp.Key.TenDiaDiem
                              });
                return result.ToList();
            }
            catch (Exception)
            {
                entity.Dispose();
            }
            return null;
        }

        public static List<ThongKeTheoTourViewModel> ThongKe(int thang, int nam)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            try
            {
                var result = (from hd in entity.HOPDONGs
                              where hd.ThoiGianDat.Value.Year == nam && hd.ThoiGianDat.Value.Month == thang
                              join ct in entity.ChiTietHopDongs
                              on hd.MaHD equals ct.MaHopDong
                              join t in entity.TOURs
                              on ct.MaTour equals t.MaTour
                              join ht in entity.HANHTRINHs
                              on t.MaHanhTrinh equals ht.MaHanhTrinh
                              join dd in entity.DIADIEMs
                              on ht.NoiDen equals dd.MaDiaDiem
                              group new { dd, ct } by new { dd.TenDiaDiem, dd.MaDiaDiem } into grp
                              select new ThongKeTheoTourViewModel()
                              {
                                  TienDaBan = grp.Sum(t => t.ct.ThanhTien),
                                  MaDiemDen = grp.Key.MaDiaDiem,
                                  TenDiemDen = grp.Key.TenDiaDiem
                              });
                return result.ToList();
            }
            catch (Exception)
            {
                entity.Dispose();
            }
            return null;

        }
    }
}