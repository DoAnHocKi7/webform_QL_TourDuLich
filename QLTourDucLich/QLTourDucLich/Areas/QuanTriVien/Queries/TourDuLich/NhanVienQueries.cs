using QLTourDucLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTourDucLich.Areas.QuanTriVien.Queries.TourDuLich
{
    public class NhanVienQueries
    {
        public static SelectList LoadHuongDanVien(object HDVChon = null)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            return new SelectList(entity.HUONGDANVIENs, "MaHDV", "TenHDV", HDVChon);
        }
    }
}