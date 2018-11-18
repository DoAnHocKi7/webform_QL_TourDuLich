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
            try
            {
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
            catch (Exception)
            {

                entity.Dispose();
            }
            return null;
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

        public static List<TourChiTietViewModel> LoadDSTour()
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            try
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
                                   TenTour = t.TenTour,
                                   TenHDV = hdv.TenHDV
                               },
                               AnhDiaDiem = t.AnhDaiDien,
                               GiaKhachSan = ks.GiaTien,
                               TGDen = t.NgayKetThuc,
                               TGDi = t.NgayKetThuc,
                               MaKS = ks.MaKS,
                           });
                return res.ToList();
            }
            catch (Exception)
            {
                entity.Dispose();
            }
            return null;
        }

        public static List<string> LayDSKhachHangDatTour(string maTour)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            try
            {
                var result = (from ct in entity.ChiTietHopDongs
                              where ct.MaTour == maTour
                              join hd in entity.HOPDONGs
                              on ct.MaHopDong equals hd.MaHD
                              group new { hd } by new { hd.MaKH } into grp
                              select grp.Key.MaKH
                              );
                return result.ToList();
            }
            catch (Exception)
            {
                entity.Dispose();
                return null;
            }
        }

        public static List<TourKhachHangDatViewModel> LayDSDatTour(string maKH)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            List<TourKhachHangDatViewModel> lst = new List<TourKhachHangDatViewModel>();
            var result = entity.InKHMuaTour(maKH).ToList();
            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    lst.Add(new TourKhachHangDatViewModel()
                    {
                        MaTour = item.MaTour,
                        SoLanDat = item.SoLuongDat
                    });
                }
            }
            return lst;
        }

        protected static List<TourKhachHangDatViewModel> TimKhachHangTotNhat(List<TourKhachHangDatViewModel> dsDatKHChinh,
                                                                                                            List<string> dsKhachHangCongTac)
        {
            Dictionary<string, List<TourKhachHangDatViewModel>> maTranDatKHPhu =
                                               new Dictionary<string, List<TourKhachHangDatViewModel>>();
            /*-------------------Lấy ma trận những người liên quan------------------*/
            foreach (var item in dsKhachHangCongTac)
            {
                maTranDatKHPhu.Add(item, LayDSDatTour(item));
            }
            Dictionary<string, double> lst_R = new Dictionary<string, double>();
            foreach (var item in maTranDatKHPhu)
            {
                lst_R.Add(item.Key, Tinh_Sim_CollaborativeFiltering(dsDatKHChinh, item.Value));
            }
            /*--------------------------------------------------------------*/
            double max_R = lst_R.Values.ToList().Max();
            string KHcongTacToiUu = lst_R.FirstOrDefault(t => t.Value == max_R).Key;
            var result = maTranDatKHPhu.FirstOrDefault(t => t.Key == KHcongTacToiUu).Value;
            return result;
        }

        protected static double Tinh_Sim_CollaborativeFiltering(List<TourKhachHangDatViewModel> userChinh,
                                               List<TourKhachHangDatViewModel> userPhu)
        {
            double average_Chinh = userChinh.Where(t => t.SoLanDat > 0).Sum(t => t.SoLanDat.Value) * 1.0 / userChinh.Count;
            double average_Phu = userPhu.Where(t => t.SoLanDat > 0).Sum(t => t.SoLanDat.Value) * 1.0 / userPhu.Count;
            double tuSo = 0;
            double mauSo = 0;
            double thuaSo1 = 0;
            double thuaSo2 = 0;
            int length = userChinh.Count;
            for (int i = 0; i < length; i++)
            {
                tuSo += (userChinh[i].SoLanDat.Value - average_Chinh) * (userPhu[i].SoLanDat.Value - average_Phu);
                thuaSo1 += Math.Pow(userChinh[i].SoLanDat.Value - average_Chinh, 2);
                thuaSo2 += Math.Pow(userPhu[i].SoLanDat.Value - average_Phu, 2);
            }
            mauSo = Math.Sqrt(thuaSo1) * Math.Sqrt(thuaSo2);
            if (mauSo != 0)
            {
                return tuSo / mauSo;
            }
            return 0;
        }

        public static List<TourChiTietViewModel> Loc_CollaborativeFiltering(string maKH, string maTourChon, int soLuongChon)
        {
            var dsDatKHChinh = LayDSDatTour(maKH);
            var bestCustomer = TimKhachHangTotNhat(dsDatKHChinh, LayDSKhachHangDatTour(maTourChon));
            //Lay Ds rate bang duc lo
            Dictionary<string, double> ketQuaChiSoR = new Dictionary<string, double>();
            foreach (var item in dsDatKHChinh)
            {
                double sim;
                if (item.SoLanDat == 0)
                {
                    sim = bestCustomer.FirstOrDefault(t => t.MaTour == item.MaTour).SoLanDat.Value;
                }
                else
                {
                    sim = item.SoLanDat.Value;
                }
                ketQuaChiSoR.Add(item.MaTour, sim);
            }
            //------------------------
            var res = ketQuaChiSoR.OrderByDescending(t => t.Value).Select(t => t.Key).ToList();
            int chiSoTourDangChon = res.FindIndex(t => t == maTourChon);
            res.RemoveAt(chiSoTourDangChon);
            var collection = res.Take(soLuongChon).ToList();
            //Lay Chi tiet Tour
            List<TourChiTietViewModel> ketQua = new List<TourChiTietViewModel>();
            if (collection.Count > 0)
            {
                foreach (var item in collection)
                {
                    ketQua.Add(TimTour(item));
                }
            }
            return ketQua;
        }

        public static List<TourChiTietViewModel> LocNoiDung(string maLoai, int soLuongChon)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            try
            {
                var res = (from t in entity.TOURs
                           where t.MaLoaiTour == maLoai
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
                                   TenTour = t.TenTour,
                                   TenHDV = hdv.TenHDV
                               },
                               AnhDiaDiem = t.AnhDaiDien,
                               GiaKhachSan = ks.GiaTien,
                               TGDen = t.NgayKetThuc,
                               TGDi = t.NgayKetThuc,
                               MaKS = ks.MaKS,
                           });
                return res.Take(soLuongChon).ToList();
            }
            catch (Exception)
            {
                entity.Dispose();
            }
            return null;
        }

        public static List<TourChiTietViewModel> LocNoiDung(decimal giaBD, decimal giaKT, int soLuongChon)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            try
            {
                var res = (from t in entity.TOURs
                           where t.GiaNguoiLon.Value >= giaBD && t.GiaNguoiLon.Value <= giaKT
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
                                   TenTour = t.TenTour,
                                   TenHDV = hdv.TenHDV
                               },
                               AnhDiaDiem = t.AnhDaiDien,
                               GiaKhachSan = ks.GiaTien,
                               TGDen = t.NgayKetThuc,
                               TGDi = t.NgayKetThuc,
                               MaKS = ks.MaKS,
                           });
                return res.Take(soLuongChon).ToList();
            }
            catch (Exception)
            {
                entity.Dispose();
            }
            return null;
        }

    }
}
