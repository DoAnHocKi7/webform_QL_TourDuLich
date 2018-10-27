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
        QlTourDuLichEntities ql = new QlTourDuLichEntities();
        public ActionResult Index()
        {
            return View();
        }
        #region Gio Hang
        // Lấy sản phẩm hiện tại có trong giỏ hàng
        public List<SPDaMua> LayGioHang()
        {
            List<SPDaMua> giohang = Session["GioHang"] as List<SPDaMua>;
            if (giohang == null)
            {
                giohang = new List<SPDaMua>();
                // vì đây session là biến toàn cục nên một lần gởi tạo là đủ 
                Session["GioHang"] = giohang;

            }
            return giohang;
        }
        // vừa vào cứ bắt sự kiện thêm vào giỏ hàng chạy trước
        public ActionResult ThemGioHang(string matour, string strURL)
        {
            //TOUR tour = ql.TOURs.SingleOrDefault(t => t.MaTour == matour);
            // Lấy ra list giỏ hàng
            List<SPDaMua> lstGioHang = LayGioHang();
            // Kiểm tra hàng này đã tồn tại trong list chưa
            SPDaMua sanpham = lstGioHang.Find(t => t.matour == matour);
            if (sanpham == null)
            {
                sanpham = new SPDaMua(matour);
                lstGioHang.Add(sanpham);
                return Redirect(strURL);

            }
            else
            {
                Response.Write("Sản Phẩm Đã Tồn Tại Trong Giỏ Hàng");
                return Redirect(strURL);
            }

        }

        // Cập nhập số lượng giỏ hàng
        public ActionResult CapNhapGioHang(string matour, FormCollection f)
        {


            List<SPDaMua> lstGioHang = LayGioHang();
            SPDaMua sanpham = lstGioHang.SingleOrDefault(t => t.matour == matour);
            if (sanpham != null)
            {
                sanpham.slnguoilon = int.Parse(f["songuoilon"].ToString());
                sanpham.sltreem = int.Parse(f["sotreem"].ToString());

            }

            return RedirectToAction("GioHang");



        }
        public ActionResult XoaGioHang(string matour)
        {

            List<SPDaMua> lstGioHang = LayGioHang();
            SPDaMua sanpham = lstGioHang.SingleOrDefault(t => t.matour == matour);
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(t => t.matour == matour);

            }
            return RedirectToAction("GioHang");

        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                //nếu sản phẩm không có gì chuyển hướng đến index trang chủ 
                return RedirectToAction("Index", "TrangChu");

            }
            List<SPDaMua> lstGioHang=LayGioHang();
            return View(lstGioHang);


        }
        //Tổng tiền của từng sản phẩm
        public decimal? TongTien()
        {
            decimal? thanhtien = 0;
            List<SPDaMua> lstGioHang = Session["GioHang"] as List<SPDaMua>;
            if (lstGioHang != null)
            {
                thanhtien = lstGioHang.Sum(t => t.thanhtien);


            }
            return thanhtien;

        }

        //Tổng số lượng có trong giỏ hàng
        public int Soluong()
        {
            int soluong = 0;
            List<SPDaMua> lstGioHang = LayGioHang();
            if (lstGioHang != null)
            {
                soluong = lstGioHang.Sum(t => t.soluong);

            }
            return soluong;

        }
        // trả về số lượng trong giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (Soluong() == 0)
            {
                return PartialView();

            }
            ViewBag.soluong = Soluong();
            return PartialView();


        }
        #endregion

     
        #region Dat Hang
        public ActionResult DatHang(FormCollection f)
        {
            Random rd = new Random();
            int ma=rd.Next(2000);
       
            List<SPDaMua> spdm = LayGioHang();
            
            KHACHHANG kh = new KHACHHANG();
            kh.MaKH = ma.ToString();
            kh.TenKH = f["customer_name"].ToString();
            kh.SDTKH=f["customer_phone"].ToString();
            kh.Email = f["customer_email"].ToString();
            kh.DCKH = f["customer_address"].ToString();
            ql.KHACHHANGs.Add(kh);
            ql.SaveChanges();
            HOPDONG hd = new HOPDONG();
            hd.MaHD = rd.Next(1000).ToString();
            hd.MaKH = kh.MaKH;
            hd.ThoiGianDat = DateTime.Now;
            hd.TongTien = TongTien();
            ql.HOPDONGs.Add(hd);
            ql.SaveChanges();
            foreach (var item in spdm)
            {
                ChiTietHopDong ctHD = new ChiTietHopDong();
                ctHD.MaCT_HopDong = rd.Next(1000).ToString();
                ctHD.MaHopDong = hd.MaHD;
                ctHD.MaTour = item.matour;
                ctHD.SLNguoiLon = item.slnguoilon;
                ctHD.SLTreEm = item.sltreem;
                ctHD.ThanhTien = item.thanhtien;
                ql.ChiTietHopDongs.Add(ctHD);
                

            }
            ql.SaveChanges();

            return View();
        }
        #endregion
    }
}
