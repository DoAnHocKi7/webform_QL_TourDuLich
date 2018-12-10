using QLTourDucLich.Areas.QuanTriVien.Queries.TourDuLich;
using QLTourDucLich.Models;
using QLTourDucLich.Queries.Tour;
using QLTourDucLich.ViewModel.GioHang;
using QLTourDucLich.ViewModel.NguoiDung;
using QLTourDucLich.ViewModel.Tour;
using System.Collections.Generic;
using System.Web.Mvc;

namespace QLTourDucLich.Controllers
{
    public class TourController : Controller
    {
        //
        // GET: /Tour/

        public ViewResult ChiTietTour(string maTour)
        {
            var model = TourQueries.TimTour(maTour);
            List<TourDaDatViewModel> gioHang =(List<TourDaDatViewModel>) Session[Constants.Constants.GIOHANG];
            ViewData["KetQuaLoc"] = TourQueries.Loc_CollaborativeFiltering(gioHang, maTour, 4);
            return View(model);
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
            paraTimKiem.NgayDi = paraTimKiem.NgayDi.AddDays(hanhDong);
            TempData["TourTimDuoc"] = TourQueries.TimTour(paraTimKiem);
            return RedirectToAction("Index", "TrangChu");
        }
    }
}
