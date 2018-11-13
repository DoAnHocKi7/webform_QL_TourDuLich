using QLTourDucLich.Areas.QuanTriVien.Queries.TourDuLich;
using QLTourDucLich.Areas.QuanTriVien.ViewModel;
using QLTourDucLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Rotativa;
using QLTourDucLich.Areas.QuanTriVien.ViewModel.Tour;
using QLTourDucLich.Areas.QuanTriVien.Queries.Thong_Ke;
using QLTourDucLich.Areas.QuanTriVien.Queries.TaiKhoan;
using QLTourDucLich.Queries.Tour;
using QLTourDucLich.ViewModel.Tour;

namespace QLTourDucLich.Areas.QuanTriVien.Controllers
{
    [CustomAuthorizeAttribute]
    public class TourDuLichController : Controller
    {
        //
        // GET: /QuanTriVien/Tour/

        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            TourQueries tourQueries = new TourQueries();
            List<TourViewModel> model = tourQueries.LayDanhSachTour();

            IPagedList<TourViewModel> iPagedList = model.ToPagedList(pageIndex, pageSize);

            return View(iPagedList);
        }

        //
        // GET: /QuanTriVien/Tour/Create

        public ActionResult ThemTour()
        {
            ThaoTacTourViewModel model = new ThaoTacTourViewModel();
            ViewBag.MaLoaiTour = model.LoaiTours;
            ViewBag.MaKS = model.KhachSans;
            ViewBag.MaDiaDiemDi = model.DiemDis;
            ViewBag.MaDiaDiemDen = model.DiemDens;
            ViewBag.HuongDanVien = model.HuongDanViens;
            return View(model);
        }

        //
        // POST: /QuanTriVien/Tour/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemTour(ThaoTacTourViewModel model)
        {
            if (!(ModelState.IsValid && TourQueries.ThemTour(model)))
            {
                TempData["KetQua"] = "thêm tour du lịch này thất bại";
                ThaoTacTourViewModel model1 = new ThaoTacTourViewModel();
                ViewBag.MaLoaiTour = model1.LoaiTours;
                ViewBag.MaKS = model1.KhachSans;
                ViewBag.MaDiaDiemDi = model1.DiemDis;
                ViewBag.MaDiaDiemDen = model1.DiemDens;
                ViewBag.HuongDanVien = model1.HuongDanViens;
                return View(model1);
            }
            TempData["KetQua"] = "thêm tour du lịch này thành công";
            return RedirectToAction("Index");
        }

        //
        // POST: /QuanTriVien/Tour/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemHanhTrinh(HanhTrinhViewModel model)
        {
            if (!(ModelState.IsValid && HanhTrinhQueries.ThemHanhTrinh(model.MaNoiDi, model.MaNoiDen)))
            {
                TempData["KetQua"] = "thêm hành trình này thất bại";
                return RedirectToAction("ThemTour");
            }
            TempData["KetQua"] = "thêm hành trình này thành công";
            return RedirectToAction("ThemTour");
        }

        //
        // GET: /QuanTriVien/Default1/Edit/5

        public ActionResult SuaTour(string id = null)
        {
            ThaoTacTourViewModel model = new ThaoTacTourViewModel(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiTour = model.LoaiTours;
            ViewBag.MaKS = model.KhachSans;
            ViewBag.MaDiaDiemDi = model.DiemDis;
            ViewBag.MaDiaDiemDen = model.DiemDens;
            ViewBag.HuongDanVien = model.HuongDanViens;
            return View(model);
        }

        //
        // POST: /QuanTriVien/Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaTour(ThaoTacTourViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("SuaTour", new { @id = model.Tour.MaTour });
            }
            if (TourQueries.ChinhSuaTour(model))
            {
                TempData["KetQua"] = "Sửa Thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["KetQua"] = "sửa Thất bại";
                return RedirectToAction("SuaTour", new { @id = model.Tour.MaTour });
            }
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

        //
        //Xoa Tour
        public ActionResult XoaTour(string id)
        {
            
if (id != null && TourQueries.XoaTour(id))
            { 
                TempData["KetQua"] = "xóa tour này thành công";
            }
            else
            {
                TempData["KetQua"] = "xóa tour này thất bại. Có thể tour đang được sử dụng";
            }
            return RedirectToAction("Index");
        }

        public ActionResult InPDF()
        {
            return new ActionAsPdf("Index");
        }

        public ActionResult ThongKe()
        {
            return new ActionAsPdf("Index");
        }

    }
}
