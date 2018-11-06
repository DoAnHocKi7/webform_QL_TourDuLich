using QLTourDucLich.Areas.QuanTriVien.ViewModel.TaiKhoan;
using QLTourDucLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTourDucLich.Areas.QuanTriVien.Queries.TaiKhoan
{
    public class TaiKhoanQueries
    {
        public static bool KiemTraDangNhap(DangNhapViewModel model)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            var result = entity.NGUOIDUNGs.FirstOrDefault(t => (t.TenDangNhap == model.Username && t.MatKhau == model.Password));
            //if (result != null)
            //{
            //    HttpContext.Current.Session[Constants.Constants.LOGIN] = model.Username;

            //    //if (model.GhiNhoDangNhap)
            //    //{
            //    //}

            //    return true;
            //}
            return result!=null;
        }
    }
}