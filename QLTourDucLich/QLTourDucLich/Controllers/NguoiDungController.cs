using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTourDucLich.Models;
using QLTourDucLich.Queries.NguoiDung;
using QLTourDucLich.ViewModel.NguoiDung;
using Facebook;
using Newtonsoft.Json;
using System.Configuration;

namespace QLTourDucLich.Controllers
{
    public class NguoiDungController : Controller
    {
        //
        // GET: /NguoiDung/
        QlTourDuLichEntities ql = new QlTourDuLichEntities();
        public ActionResult NguoiDung()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(KhachHangDangKyViewModel model)
        {
            Random rd = new Random();
            model.MaKH = rd.Next(2000).ToString();
            if (ModelState.IsValid)
            {
                try
                {
                    KHACHHANG khachhang = new KHACHHANG()
                    {
                        MaKH = model.MaKH,
                        TenKH = model.TenKH,
                        NgSinh = model.NgaySinh,
                        Email = model.Email,
                        SDTKH = model.Phone,
                        Password = model.MatKhau
                    };
                    ql.KHACHHANGs.Add(khachhang);
                    ql.SaveChanges();
                    ViewBag.ThongBao = "Chúc Mừng Bạn Đăng Ký Thành  Công";
                    Session["TaiKhoan"] = khachhang.TenKH;
                    return RedirectToAction("Index", "TrangChu");
                }
                catch
                {

                }

            }
            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            KhachHangDangNhapViewModel model = new KhachHangDangNhapViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult DangNhap(KhachHangDangNhapViewModel model)
        {
            if (ModelState.IsValid)
            {
                KhachHangViewModel khachHang = KhachHangQueries.DangNhap(model);
                if (khachHang != null)
                {
                    ViewBag.ThongBao = "Đăng nhập thành công";
                    Session[Constants.Constants.LOGIN_KHACHHANG] = khachHang.TenKH;
                    Session["Login"] = model;
                    return RedirectToAction("Index", "TrangChu");

                }
            }
            ViewBag.ThongBao = "Đăng nhập thất bại";
            return View();
        }

        public ActionResult DangXuat()
        {
            Session[Constants.Constants.LOGIN_KHACHHANG] = null;
            return RedirectToAction("Index", "TrangChu");
        }

        private Uri RediredtUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

    }
}
