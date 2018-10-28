using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTourDucLich.Models;
using QLTourDucLich.ViewModel;

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
        #region Đăng Ký
        [HttpGet]
        public ActionResult DangKy()
        {
         
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KHACHHANGViewModel KH)
        {
            Random rd = new Random();
            KH.MaKH = rd.Next(2000).ToString();
            if (ModelState.IsValid)
            {


                try
                {
                    KHACHHANG khachhang = new KHACHHANG()
                    {
                        MaKH=KH.MaKH,
                        TenKH = KH.TenKH,
                        NgSinh=KH.NgaySinh,
                        Email=KH.Email,
                        SDTKH=KH.Phone,
                        Password=KH.MatKhau



                    };
                  ql.KHACHHANGs.Add(khachhang);
                  ql.SaveChanges();
                }
                catch
                {

                }
             

            }
            
            return View();
        }
        #endregion

        #region Đăng Nhập
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
                Session["TaiKhoan"] = kh;
                return RedirectToAction("Index", "TrangChu");

            }
            return View();


        }




        #endregion


    }
}
