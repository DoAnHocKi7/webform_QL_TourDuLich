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
    }
}