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
using QLTourDucLich.Constants;
using QLTourDucLich.ViewModel.NguoiDung;

namespace QLTourDucLich.Controllers
{
    public class TourController : Controller
    {
        //
        // GET: /Tour/

        public ViewResult ChiTietTour(string matour)
        {
            var model = TourQueries.TimTour(matour);
            if (Session[Constants.Constants.LOGIN_KHACHHANG] == null)
            {
                ViewData["KetQuaLoc"] = TourQueries.LocNoiDung(model.Tour.GiaNguoiLon.Value-500000, 
                                                            model.Tour.GiaNguoiLon.Value + 500000, 2)
                                .Concat(TourQueries.LocNoiDung(model.Tour.LoaiTour, 2)).ToList();
            }
            else
            {
                string maKH = ((KhachHangViewModel)Session[Constants.Constants.LOGIN_KHACHHANG]).MaKH;
                ViewData["KetQuaLoc"] = TourQueries.Loc_CollaborativeFiltering(maKH, matour, 4);
            }
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
            paraTimKiem.NgayDi = paraTimKiem.NgayDi .AddDays(hanhDong);
            TempData["TourTimDuoc"] = TourQueries.TimTour(paraTimKiem);
            return RedirectToAction("Index", "TrangChu");
        }
    }
}
