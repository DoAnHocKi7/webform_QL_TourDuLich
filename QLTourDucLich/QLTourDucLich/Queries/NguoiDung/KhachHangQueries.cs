using QLTourDucLich.Models;
using QLTourDucLich.ViewModel.NguoiDung;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTourDucLich.Queries.NguoiDung
{
    public class KhachHangQueries
    {
        public static KhachHangViewModel TimKhachHang(string maHopDong)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            string maKH = entity.HOPDONGs.FirstOrDefault(t => t.MaHD == maHopDong).MaKH;
            var result = entity.KHACHHANGs.FirstOrDefault(t => t.MaKH == maKH);
            if (result == null)
            {
                return null;
            }
            return new KhachHangViewModel()
            {
                DiaChi = result.DCKH,
                SoDT = result.SDTKH,
                TenKH = result.TenKH
            };
        }

        public static KhachHangViewModel DangNhap(KhachHangDangNhapViewModel model)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            var result = entity.KHACHHANGs.FirstOrDefault(t => (t.Email == model.TenDangNhap.Trim() || t.SDTKH == model.TenDangNhap.Trim())
                                                             && t.Password == model.MatKhau.Trim());
            if (result == null)
            {
                return null;
            }
            return new KhachHangViewModel()
            {
                TenKH = result.TenKH,
                SoDT = result.SDTKH,
                DiaChi = result.DCKH,
                Email = result.Email,
                GioiTinh = result.GioiTinh
            };
        }

        public static bool KiemTraTaiKhoanFacebook(string idKH)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            return entity.KHACHHANGs.FirstOrDefault(t => t.MaKH == idKH) != null;
        }

        public static bool DangKy(KhachHangViewModel model)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            KHACHHANG khachhang = new KHACHHANG()
            {
                MaKH = model.MaKH,
                Email = model.Email,
                GioiTinh = model.GioiTinh,
                SDTKH = model.SoDT,
                TenKH = model.TenKH
            };
            try
            {
                entity.KHACHHANGs.Add(khachhang);
                entity.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                entity.Dispose();
            }
            return false;
        }
    }
}