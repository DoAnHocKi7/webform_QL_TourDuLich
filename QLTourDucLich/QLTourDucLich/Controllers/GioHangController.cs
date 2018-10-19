﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTourDucLich.Models;

namespace QLTourDucLich.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        QlTourDuLichEntities1 ql = new QlTourDuLichEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public List<GioHang> LayGioHang()
        {
            List<GioHang> giohang = Session["GioHang"] as List<GioHang>;
            if (giohang == null)
            {
                giohang = new List<GioHang>();
                Session["GioHang"] = giohang;

            }

            return giohang;


        }
        // vừa vào cứ bắt sự kiện thêm vào giỏ hàng chạy trước
        public ActionResult ThemGioHang(string matour, string strURL)
        {
            //TOUR tour = ql.TOURs.SingleOrDefault(t => t.MaTour == matour);
            // Lấy ra list giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            // Kiểm tra hàng này đã tồn tại trong list chưa
            GioHang sanpham = lstGioHang.Find(t => t.matour == matour);
            if (sanpham == null)
            {
                sanpham = new GioHang(matour);
                lstGioHang.Add(sanpham);
                return Redirect(strURL);

            }
            else
            {
                sanpham.soluong++;
                return Redirect(strURL);
            }

        }
        public ActionResult CapNhapGioHang(string matour, FormCollection f)
        {

            TOUR tour = ql.TOURs.SingleOrDefault(t => t.MaTour == matour);

            if (tour == null)
            {
                Response.StatusCode = 404;
                return null;


            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(t => t.matour == matour);
            if (sanpham != null)
            {
                sanpham.soluong = int.Parse(f["txtsoluong"].ToString());

            }

            return View("GioHang");



        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "TrangChu");


            }
            List<GioHang> lstGioHang=LayGioHang();
            return View(lstGioHang);


        }
        public float TongTien()
        {
            float thanhtien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                thanhtien = lstGioHang.Sum(t => t.thanhtien);


            }
            return thanhtien;

        }

    }
}
