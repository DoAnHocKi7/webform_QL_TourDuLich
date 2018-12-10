using QLTourDucLich.Areas.QuanTriVien.ViewModel;
using QLTourDucLich.Areas.QuanTriVien.ViewModel.Tour;
using QLTourDucLich.Models;
using QLTourDucLich.ViewModel.GioHang;
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

        public static List<TourDaDatViewModel> LayDSTourGioHang(List<TourDaDatViewModel> gioHang)
        {
            QlTourDuLichEntities entities = new QlTourDuLichEntities();
            var foods = entities.TOURs.Select(t => t.MaTour).ToList().OrderBy(t => t);
            List<TourDaDatViewModel> res = new List<TourDaDatViewModel>();
            TourDaDatViewModel tour;

            if (gioHang == null)
            {
                foreach (var item in foods)
                {
                    tour = new TourDaDatViewModel() { matour = item, soluong = 0 };
                    res.Add(tour);
                }
            }
            else
            {
                foreach (var item in foods)
                {
                    var tourChon = gioHang.FirstOrDefault(t => t.matour == item);
                    if (tourChon != null)
                    {
                        tour = new TourDaDatViewModel() { matour = item, soluong = tourChon.soluong };
                    }
                    else
                    {
                        tour = new TourDaDatViewModel() { matour = item, soluong = 0 };
                    }
                    res.Add(tour);
                }

            }
            return res;
        }

        public static List<string> TimHD(string idTour)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            try
            {
                var result = (from ct in entity.ChiTietHopDongs
                              where ct.MaTour == idTour
                              group new { ct } by new { ct.MaHopDong } into grp
                              select grp.Key.MaHopDong
                              );
                return result.ToList();
            }
            catch (Exception)
            {
                entity.Dispose();
                return null;
            }
        }

        public static List<TourDaDatViewModel> LayDSTourDaDat(string idHD)
        {
            QlTourDuLichEntities entities = new QlTourDuLichEntities();
            List<TourDaDatViewModel> lst = new List<TourDaDatViewModel>();
            var result = entities.InHopDong(idHD).ToList();
            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    lst.Add(new TourDaDatViewModel()
                    {
                        matour = item.MaTour,
                        soluong = item.SoLuongDat
                    });
                }
            }
            return lst;
        }

        protected static List<TourDaDatViewModel> TimHoaDonTotNhat(List<TourDaDatViewModel> choosingFoods,
                                                                                             List<string> hoaDonLst)
        {
            Dictionary<string, List<TourDaDatViewModel>> matrix =
                                               new Dictionary<string, List<TourDaDatViewModel>>();
            foreach (var item in hoaDonLst)
            {
                matrix.Add(item, LayDSTourDaDat(item));
            }
            Dictionary<string, double> lst_R = new Dictionary<string, double>();
            foreach (var item in matrix)
            {
                lst_R.Add(item.Key, Tinh_Sim_CollaborativeFiltering(choosingFoods, item.Value));
            }
            try
            {
                double max_R = lst_R.Values.ToList().Max();
                string bestHD = lst_R.FirstOrDefault(t => t.Value == max_R).Key;
                var result = matrix.FirstOrDefault(t => t.Key == bestHD).Value;
                return result;

            }
            catch (Exception)
            {
                return null;//mon chua duoc ban lan nao
            }
        }

        protected static double Tinh_Sim_CollaborativeFiltering(List<TourDaDatViewModel> choosingFoods,
                                       List<TourDaDatViewModel> collabrator)
        {
            double average_Main = choosingFoods.Where(t => t.soluong > 0).Sum(t => t.soluong) * 1.0 / choosingFoods.Count;
            double average_Temp = collabrator.Where(t => t.soluong > 0).Sum(t => t.soluong) * 1.0 / collabrator.Count;
            double tuSo = 0;
            double mauSo = 0;
            double thuaSo1 = 0;
            double thuaSo2 = 0;
            int length = choosingFoods.Count;
            for (int i = 0; i < length; i++)
            {
                tuSo += (choosingFoods[i].soluong - average_Main) * (collabrator[i].soluong - average_Temp);
                thuaSo1 += Math.Pow(choosingFoods[i].soluong - average_Main, 2);
                thuaSo2 += Math.Pow(collabrator[i].soluong - average_Temp, 2);
            }
            mauSo = Math.Sqrt(thuaSo1) * Math.Sqrt(thuaSo2);
            if (mauSo != 0)
            {
                return tuSo / mauSo;
            }
            return 0;
        }

        public static List<TourChiTietViewModel> Loc_CollaborativeFiltering(List<TourDaDatViewModel> cart, string maTourChon, int soLuongChon)
        {
            var dsTourGioHang = LayDSTourGioHang(cart);
            var bestCustomer = TimHoaDonTotNhat(dsTourGioHang, TimHD(maTourChon));
            if (bestCustomer != null)
            {
                //Lay Ds rate bang duc lo
                Dictionary<string, double> ketQuaChiSoR = new Dictionary<string, double>();
                foreach (var item in dsTourGioHang)
                {
                    double sim;
                    if (item.soluong == 0)
                    {
                        sim = bestCustomer.FirstOrDefault(t => t.matour == item.matour).soluong;
                    }
                    else
                    {
                        sim = item.soluong;
                    }
                    ketQuaChiSoR.Add(item.matour, sim);
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
                        ketQua.Add(TourQueries.TimTour(item));
                    }
                }
                return ketQua;
            }
            return null;
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
