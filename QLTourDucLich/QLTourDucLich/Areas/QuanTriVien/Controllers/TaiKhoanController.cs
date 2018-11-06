using QLTourDucLich.Areas.QuanTriVien.Queries.TaiKhoan;
using QLTourDucLich.Areas.QuanTriVien.ViewModel;
using QLTourDucLich.Areas.QuanTriVien.ViewModel.TaiKhoan;
using QLTourDucLich.Areas.QuanTriVien.ViewModel.Tour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTourDucLich.Areas.QuanTriVien.Controllers
{
    public class TaiKhoanController : Controller
    {

        public ActionResult DangNhap()
        {
            DangNhapViewModel model = new DangNhapViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult DangNhap(DangNhapViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (TaiKhoanQueries.KiemTraDangNhap(model))
                {
                    Session[Constants.Constants.LOGIN] = model.Username;
                    if (Response.Cookies[Constants.Constants.LOGIN] != null)
                    {
                        Response.Cookies.Remove(Constants.Constants.LOGIN);
                    }
                    Response.Cookies[Constants.Constants.LOGIN].Value = model.Username;
                    Response.Cookies[Constants.Constants.LOGIN][Constants.Constants.DANGNHAPLANCUOI] = DateTime.Now.ToString();
                    Response.Cookies[Constants.Constants.LOGIN].Expires = DateTime.Now.AddDays(15);
                    return RedirectToAction("Index", "Tour");
                }
            }
            return View(model);
        }

    }
}
