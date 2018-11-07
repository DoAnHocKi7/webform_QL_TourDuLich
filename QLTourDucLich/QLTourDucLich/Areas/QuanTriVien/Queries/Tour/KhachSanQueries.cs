using QLTourDucLich.Areas.QuanTriVien.ViewModel;
using QLTourDucLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace QLTourDucLich.Areas.QuanTriVien.Queries.Tour
{
    public class KhachSanQueries
    {

        public static SelectList LayDsKhachSan()
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            //var result = entity.KHACHSANs.Select(t => new SelectListItem() { Value = t.MaKS, Text = t.TenKS });
            var result = new SelectList(entity.KHACHSANs, "MaKS", "TenKS");
            return result;
        }

        public static SelectList LayDsKhachSan(string maKS)
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            //var result = entity.KHACHSANs.Select(t => new SelectListItem() { Value = t.MaKS, Text = t.TenKS });
            var result = new SelectList(entity.KHACHSANs, "MaKS", "TenKS",maKS);
            return result;
        }
    }
}
