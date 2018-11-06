using QLTourDucLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace QLTourDucLich.Controllers
{
    public class TimKiemController : Controller
    {
        //
        // GET: /TimKiem/
        
        QlTourDuLichEntities ql = new QlTourDuLichEntities();
        [HttpPost]
        public ActionResult TimKiemTour(FormCollection f,int ?page)
        {
            string TenDiaDiem = f["Tendiadiem"].ToString();
            DateTime? NgayDi = Convert.ToDateTime(f["ngaydi"].ToString());
            DateTime? NgayDen =Convert.ToDateTime(f["ngayden"].ToString());
            int pageSize = 8;

            ViewBag.TenDiaDiem = TenDiaDiem;
            ViewBag.NgayDi = NgayDi;
            ViewBag.NgayDen = NgayDen;

            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var ListTour = (from t in ql.TOURs                           
                            join ht in ql.HANHTRINHs
                            on t.MaHanhTrinh equals ht.MaHanhTrinh
                            join dd1 in ql.DIADIEMs
                            on ht.NoiDen equals dd1.MaDiaDiem
                            join dd2 in ql.DIADIEMs
                            on ht.NoiDi equals dd2.MaDiaDiem
                                    where dd2.TenDiaDiem == TenDiaDiem && t.NgayKhoiHanh == NgayDi && t.NgayKetThuc == NgayDen
                                  select new TourDTO()
                                  {
                                     MaTour=t.MaTour,
                                     TenTour=t.TenTour,
                                     AnhDaiDien=t.AnhDaiDien
                                     
                                        
                                  });
            if (ListTour.Count() == 0)
            {
                ViewBag.ThongBao = "Không Tìm Thấy Sản Phảm Nào";

            }


            ViewBag.ThongBao = "Tìm Thấy :" + ListTour.Count();

            return View(ListTour.ToList<TourDTO>().OrderBy(t=>t.TenTour).ToPagedList(pageIndex, pageSize));

        }

    

         

  
            



     


      

    }
}
