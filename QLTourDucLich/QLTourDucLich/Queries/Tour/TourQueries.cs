using QLTourDucLich.Areas.QuanTriVien.ViewModel;
using QLTourDucLich.Areas.QuanTriVien.ViewModel.Tour;
using QLTourDucLich.Models;
using QLTourDucLich.ViewModel.Tour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using WebComponent;

namespace QLTourDucLich.Queries.Tour
{
    public class TourQueries
    {
        QlTourDuLichEntities entity = new QlTourDuLichEntities();

        public List<TourViewModel> LayDanhSachTour()
        {
            var res = (from t in entity.TOURs
                       join ks in entity.KHACHSANs
                       on t.MaKS equals ks.MaKS
                       join l in entity.LOAITOURs
                       on t.MaLoaiTour equals l.MaLoaiTour
                       join ht in entity.HANHTRINHs
                       on t.MaHanhTrinh equals ht.MaHanhTrinh
                       join dd1 in entity.DIADIEMs
                       on ht.NoiDen equals dd1.MaDiaDiem
                       join dd2 in entity.DIADIEMs
                       on ht.NoiDi equals dd2.MaDiaDiem
                       select new TourViewModel()
                       {
                           MaTour = t.MaTour,
                           //AnhDiaDiem=t.AnhDaiDien,
                           NgayKH = t.NgayKhoiHanh,
                           NgayKT = t.NgayKetThuc,
                           TenKhachSan = ks.TenKS,
                           DiemDen = dd1.TenDiaDiem,
                           DiemDi = dd2.TenDiaDiem,
                           GiaNguoiLon = t.GiaNguoiLon,
                           GiaTreEm = t.GiaTreEm,
                           LoaiTour = l.TenLoaiTour,
                           TenTour = t.TenTour
                           //MaDiemDen = dd1.MaDiaDiem,
                           //MaDiemDi = dd2.MaDiaDiem
                       });
            return res.ToList<TourViewModel>();
        }

        public List<TourViewModel> TimTour(DateTime ngayKH, int? maNoiDi, int? maNoiDen)
        {
            var res = (from t in entity.TOURs
                       join ks in entity.KHACHSANs
                       on t.MaKS equals ks.MaKS
                       join ht in entity.HANHTRINHs
                       on t.MaHanhTrinh equals ht.MaHanhTrinh
                       join dd1 in entity.DIADIEMs
                       on ht.NoiDen equals dd1.MaDiaDiem
                       join dd2 in entity.DIADIEMs
                       on ht.NoiDi equals dd2.MaDiaDiem
                       where t.NgayKhoiHanh == ngayKH && ht.NoiDi == maNoiDi && ht.NoiDen == maNoiDen
                       select new TourViewModel()
                       {
                           MaTour = t.MaTour,

                           NgayKH = t.NgayKhoiHanh,
                           NgayKT = t.NgayKetThuc,
                           TenKhachSan = ks.TenKS,
                           DiemDen = dd1.TenDiaDiem,
                           DiemDi = dd2.TenDiaDiem,

                       });


            return res.ToList<TourViewModel>();
        }

        public static List<TourChiTietViewModel> TimTour(TimKiemTourViewModel model)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            var res = (from t in entity.TOURs
                           //join ks in entity.KHACHSANs
                           //on t.MaKS equals ks.MaKS
                       join ht in entity.HANHTRINHs
                       on t.MaHanhTrinh equals ht.MaHanhTrinh
                       join dd1 in entity.DIADIEMs
                       on ht.NoiDen equals dd1.MaDiaDiem
                       join dd2 in entity.DIADIEMs
                       on ht.NoiDi equals dd2.MaDiaDiem
                       where t.NgayKhoiHanh.Value.Year == model.NgayDi.Year
                       && t.NgayKhoiHanh.Value.Month == model.NgayDi.Month
                       && t.NgayKhoiHanh.Value.Day == model.NgayDi.Day
                       select new TourChiTietViewModel()
                       {
                           Tour = new TourViewModel()
                           {
                               MaTour = t.MaTour,
                               NgayKH = t.NgayKhoiHanh,
                               NgayKT = t.NgayKetThuc,
                               //TenKhachSan = ks.TenKS,
                               DiemDen = dd1.TenDiaDiem,
                               DiemDi = dd2.TenDiaDiem,
                               GiaNguoiLon = t.GiaNguoiLon,
                               GiaTreEm = t.GiaTreEm
                           },
                           AnhDiaDiem = t.AnhDaiDien
                       });

            return res.ToList();
        }

        public static TourChiTietViewModel TimTour(string maTour)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();

            var res = (from t in entity.TOURs
                       where t.MaTour == maTour
                       join ks in entity.KHACHSANs
                       on t.MaKS equals ks.MaKS
                       join ht in entity.HANHTRINHs
                       on t.MaHanhTrinh equals ht.MaHanhTrinh
                       join dd1 in entity.DIADIEMs
                       on ht.NoiDen equals dd1.MaDiaDiem
                       join dd2 in entity.DIADIEMs
                       on ht.NoiDi equals dd2.MaDiaDiem
                       join hdv in entity.HUONGDANVIENs
                       on t.MaHDV equals hdv.MaHDV
                       select new TourChiTietViewModel()
                       {
                           Tour = new TourViewModel()
                           {
                               MaTour = t.MaTour,
                               LoaiTour = t.MaLoaiTour,
                               NgayKH = t.NgayKhoiHanh,
                               NgayKT = t.NgayKetThuc,
                               TenKhachSan = ks.TenKS,
                               DiemDen = dd1.TenDiaDiem,
                               DiemDi = dd2.TenDiaDiem,
                               GiaNguoiLon = t.GiaNguoiLon,
                               GiaTreEm = t.GiaTreEm,
                               MaDiaDiemDen = ht.NoiDen,
                               MaDiaDiemDi = ht.NoiDi,
                               TenTour = t.TenTour,
                               MaHDV = hdv.MaHDV,
                               TenHDV = hdv.TenHDV
                           },
                           AnhDiaDiem = t.AnhDaiDien,
                           GiaKhachSan = ks.GiaTien,
                           TGDen = t.NgayKetThuc,
                           TGDi = t.NgayKetThuc,
                           MaKS = ks.MaKS,

                       });
            return res.FirstOrDefault();

        }

        public static bool ThemTour(ThaoTacTourViewModel tourDTO)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            try
            {
                TOUR tour = new TOUR()
                {
                    MaTour = new Random().Next(0, 10000).ToString(),
                    //AnhDaiDien = tourDTO.AnhDiaDiem,
                    GiaNguoiLon = tourDTO.Tour.GiaNguoiLon,
                    GiaTreEm = tourDTO.Tour.GiaTreEm,
                    MaHanhTrinh = entity.HANHTRINHs.FirstOrDefault(t => (t.NoiDi == tourDTO.Tour.MaDiaDiemDi
                                      && t.NoiDen == tourDTO.Tour.MaDiaDiemDen)).MaHanhTrinh,
                    MaHDV = tourDTO.Tour.MaHDV,
                    MaKS = tourDTO.KhachSan,
                    MaLoaiTour = tourDTO.Tour.LoaiTour,
                    NgayKetThuc = tourDTO.Tour.NgayKT,
                    NgayKhoiHanh = tourDTO.Tour.NgayKH,
                };
                entity.TOURs.Add(tour);
                entity.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                entity.Dispose();
            }
            return false;
        }

        public static bool XoaTour(string MaTour)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            try
            {
                entity.TOURs.Remove(entity.TOURs.Where(t => t.MaTour == MaTour).FirstOrDefault());
                entity.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                entity.Dispose();
            }
            return false;
        }

        public static bool ChinhSuaTour(ThaoTacTourViewModel tourViewModel)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            try
            {
                TOUR tour = entity.TOURs.Where(t => t.MaTour == tourViewModel.Tour.MaTour).FirstOrDefault();
                tour.MaTour = tourViewModel.Tour.MaTour;
                tour.TenTour = tourViewModel.Tour.TenTour;
                //tour.AnhDaiDien = tourViewModel.AnhDiaDiem;
                tour.GiaNguoiLon = tourViewModel.Tour.GiaNguoiLon;
                tour.GiaTreEm = tourViewModel.Tour.GiaTreEm;
                tour.MaHanhTrinh = entity.HANHTRINHs.FirstOrDefault(t => (t.NoiDen == tourViewModel.Tour.MaDiaDiemDen)
                                  && t.NoiDi == tourViewModel.Tour.MaDiaDiemDi).MaHanhTrinh;
                tour.MaHDV = tourViewModel.Tour.MaHDV;
                tour.MaKS = tourViewModel.KhachSan;
                tour.MaLoaiTour = tourViewModel.Tour.LoaiTour;
                tour.NgayKetThuc = tourViewModel.Tour.NgayKT;
                tour.NgayKhoiHanh = tourViewModel.Tour.NgayKH;
                entity.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                entity.Dispose();
                return false;
            }
        }

        public static SelectList LoadLoaiTour()
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            return new SelectList(entity.LOAITOURs, "MaLoaiTour", "TenLoaiTour");
        }

        public static SelectList LoadLoaiTour(string maLoaiDuocChon)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            return new SelectList(entity.LOAITOURs, "MaLoaiTour", "TenLoaiTour", maLoaiDuocChon);
        }

    }
}
