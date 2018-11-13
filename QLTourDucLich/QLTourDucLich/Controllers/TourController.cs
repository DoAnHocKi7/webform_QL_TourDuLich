using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTourDucLich.Models;
using PagedList;
using PagedList.Mvc;
using QLTourDucLich.Queries.Tour;
using QLTourDucLich.Areas.QuanTriVien.Queries.TourDuLich;
using QLTourDucLich.ViewModel.Tour;

namespace QLTourDucLich.Controllers
{
    public class TourController : Controller
    {
        //
        // GET: /Tour/
        QlTourDuLichEntities ql = new QlTourDuLichEntities();

        public ViewResult ChiTietTour(string matour)
        {

            ChiTietT tour = new ChiTietT(matour);
            List<ChiTietT> listtour = new List<ChiTietT>();
            listtour.Add(tour);
            return View(listtour);
        }

        // [HttpPost]
        public ActionResult TimKiemTour(TimKiemTourViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["TourTimDuoc"] = TourQueries.TimTour(model);
                TempData["ThongTinTimKiem"] = model;
            }
            return RedirectToAction("Index", "TrangChu");
        }

        //
        //Bound diem den
        public ActionResult TimDiemDen(string maNoiDi)
        {
            if (string.IsNullOrEmpty(maNoiDi))
            {
                return Json(null);
            }
            var lstNoiDen = DiaDiemQueries.TimDiemDen(int.Parse(maNoiDi));
            return Json(lstNoiDen);
        }

        public ActionResult ChuyenHuongTimKiem(double hanhDong)
        {
            var paraTimKiem = (TimKiemTourViewModel)TempData["ThongTinTimKiem"];
            paraTimKiem.NgayDi = paraTimKiem.NgayDi .AddDays(hanhDong);
            TempData["TourTimDuoc"] = TourQueries.TimTour(paraTimKiem);
            return RedirectToAction("Index", "TrangChu");
        }
    }
}
