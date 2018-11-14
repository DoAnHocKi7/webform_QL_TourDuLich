using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTourDucLich.Models;
using QLTourDucLich.ViewModel.NguoiDung;

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
                        MaKH=model.MaKH,
                        TenKH = model.TenKH,
                        NgSinh=model.NgaySinh,
                        Email=model.Email,
                        SDTKH=model.Phone,
                        Password=model.MatKhau
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
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string email = f["txtEmail"].ToString();
            string matkhau = f["txtMatKhau"].ToString();
            KHACHHANG kh = ql.KHACHHANGs.SingleOrDefault(t => t.Email == email && t.Password == matkhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "Chúc Mừng Bạn Đăng Nhập Thành Công";
                Session["TaiKhoan"] = kh.TenKH;
                Session["Login"] = kh;
                return RedirectToAction("Index", "TrangChu");
            }
            else
            {
                ViewBag.ThongBao = "Đăng Nhập Thất Bại";
            }
            return View();
        }

        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "TrangChu");
        }  

    }
}
