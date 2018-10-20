using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTourDucLich.Models
{
    public class DSTour
    {
        public QlTourDuLichEntities1 ql;
        public string tentour { get; set; }
        public string tendiadiem { get; set; }
        public string hinhanh { get; set; }
        public string matour { get; set; }
        public string anhdaidien { get; set; }
        public DSTour()
        {
            ql = new QlTourDuLichEntities1();
            var tour = (from t in ql.TOURs
                        join ht in ql.HANHTRINHs on t.MaHanhTrinh equals ht.MaHanhTrinh
                        join dd in ql.DIADIEMs on ht.NoiDen equals dd.MaDiaDiem
               

                        select new
                        {

                            tentour = t.TenTour,
                            hinhanh = t.AnhDaiDien,
                            tendiadiem = dd.TenDiaDiem
                            
                        }).Take(4);



            // }
        }
    }
}