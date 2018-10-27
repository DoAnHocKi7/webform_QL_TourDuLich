using QLTourDucLich.Areas.QuanTriVien.ViewModel;
using QLTourDucLich.Models;
using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTourDucLich.Areas.QuanTriVien.Queries
{
    public class DiaDiemQueries
    {
        QlTourDuLichEntities entities = new QlTourDuLichEntities();
        public List<DiaDiemViewModel> LayDiaDiem()
        {
            var result = (from ht in entities.HANHTRINHs
                          join dd in entities.DIADIEMs
                          on ht.NoiDen equals dd.MaDiaDiem
                          select new DiaDiemViewModel()
                          {
                              MaDiaDiem = dd.MaDiaDiem,
                              TenDiaDiem = dd.TenDiaDiem
                          });
            return result.ToList<DiaDiemViewModel>();
        }

        //public List<DiaDiemViewModel> TimDiemDen(int? MaDiemDi)
        //{
        //    var result = (from ht in entities.HANHTRINHs
        //                  join dd in entities.DIADIEMs
        //                  on ht.NoiDen equals dd.MaDiaDiem
        //                  where ht.NoiDi == MaDiemDi
        //                  select new DiaDiemViewModel()
        //                  {
        //                      MaDiaDiem = dd.MaDiaDiem,
        //                      TenDiaDiem = dd.TenDiaDiem
        //                  });
        //    return result.ToList<DiaDiemViewModel>();
        //}

        public static List<SelectListItem> LoadDiaDiem()
        {
            QlTourDuLichEntities entities = new QlTourDuLichEntities();

            var result = (from ht in entities.HANHTRINHs
                          join dd in entities.DIADIEMs
                          on ht.NoiDen equals dd.MaDiaDiem
                          select new SelectListItem()
                          {
                              Value = SqlFunctions.StringConvert((double) dd.MaDiaDiem).Trim(),
                              Text = dd.TenDiaDiem
                          });
            return result.ToList();
        }

        public static List<SelectListItem> TimDiemDen(int? MaDiemDi)
        {
            QlTourDuLichEntities entities = new QlTourDuLichEntities();
            var result = (from ht in entities.HANHTRINHs
                          join dd in entities.DIADIEMs
                          on ht.NoiDen equals dd.MaDiaDiem
                          where ht.NoiDi == MaDiemDi
                          select new SelectListItem()
                          {
                              Value = SqlFunctions.StringConvert((double)dd.MaDiaDiem).Trim(),
                              Text = dd.TenDiaDiem
                          });
            return result.ToList();
        }


    }
}