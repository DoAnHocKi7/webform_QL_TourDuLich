using QLTourDucLich.Areas.QuanTriVien.ViewModel;
using QLTourDucLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace QLTourDucLich.Areas.QuanTriVien.Queries
{
    public class KhachSanQueries
    {

        public static List<SelectListItem> LayDsKhachSan()
        {
            QlTourDuLichEntities entity = new QlTourDuLichEntities();
            var result = entity.KHACHSANs.Select(t => new SelectListItem() { Value = t.MaKS, Text = t.TenKS });
            return result.ToList();
        }
    }
}
