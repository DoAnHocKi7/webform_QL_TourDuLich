using QLTourDucLich.Areas.QuanTriVien.ViewModel;
using QLTourDucLich.Models;
using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTourDucLich.Areas.QuanTriVien.Queries.TourDuLich
{
    public class DiaDiemQueries
    {

        public static SelectList LoadDiaDiem(string selectedDiaDiem = null)
        {
            QlTourDuLichEntities entities = new QlTourDuLichEntities();
            if (selectedDiaDiem == null)
            {
                return new SelectList(entities.DIADIEMs, "MaDiaDiem", "TenDiaDiem", entities.DIADIEMs.FirstOrDefault().MaDiaDiem);
            }
            return new SelectList(entities.DIADIEMs, "MaDiaDiem", "TenDiaDiem", selectedDiaDiem);

        }

        public static SelectList TimDiemDen2(int? MaDiemDi)
        {
            QlTourDuLichEntities entities = new QlTourDuLichEntities();
            try
            {
                var result = (from ht in entities.HANHTRINHs
                              join dd in entities.DIADIEMs
                              on ht.NoiDen equals dd.MaDiaDiem
                              where ht.NoiDi == MaDiemDi
                              select new 
                              {
                                  dd.TenDiaDiem,dd.MaDiaDiem
                              });
                return new SelectList(result, "MaDiaDiem", "TenDiaDiem",result.FirstOrDefault().MaDiaDiem);

            }
            catch (Exception)
            {

                entities.Dispose();
                return null;
            }
        }


        public static List<SelectListItem> TimDiemDen(int? MaDiemDi)
        {
            QlTourDuLichEntities entities = new QlTourDuLichEntities();
            try
            {
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
            catch (Exception)
            {

                entities.Dispose();
                return new List<SelectListItem>();
            }
        }
    }
}