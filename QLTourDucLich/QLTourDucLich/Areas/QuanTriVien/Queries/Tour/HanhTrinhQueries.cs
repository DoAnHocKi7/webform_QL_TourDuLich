using QLTourDucLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTourDucLich.Areas.QuanTriVien.Queries.Tour
{
    public class HanhTrinhQueries
    {
        public static bool ThemHanhTrinh(int maNoiDi, int maNoiDen)
        {
            QlTourDuLichEntities entities = new QlTourDuLichEntities();
            if (maNoiDi != maNoiDen && entities.HANHTRINHs.FirstOrDefault(t => (t.NoiDi == maNoiDi && t.NoiDen == maNoiDen)) == null)
            {

                try
                {
                    entities.HANHTRINHs.Add(new HANHTRINH()
                    {
                        MaHanhTrinh = new Random().Next(0, 1000).ToString(),
                        NoiDi = maNoiDi,
                        NoiDen = maNoiDen
                    });
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    entities.Dispose();
                }
            }
            return false;
        }
    }
}