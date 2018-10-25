using System;
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
        // Lấy sản phẩm hiện tại có trong giỏ hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> giohang = Session["GioHang"] as List<GioHang>;
            if (giohang == null)
            {
                giohang = new List<GioHang>();
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

        // Cập nhập số lượng giỏ hàng
        public ActionResult CapNhapGioHang(string matour, FormCollection f)
        {

           
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(t => t.matour == matour);
            if (sanpham != null)
            {
                sanpham.soluong = int.Parse(f["txtsoluong"].ToString());

            }

            return RedirectToAction("GioHang");



        }
        public ActionResult XoaGioHang(string matour)
        {

            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(t => t.matour == matour);
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
                //vẫn ở lại trang hiện tại 
                return RedirectToAction("Index", "TrangChu");

            }
            List<GioHang> lstGioHang=LayGioHang();
            return View(lstGioHang);


        }
        //Tổng tiền của từng sản phẩm
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

        //Tổng số lượng có trong giỏ hàng
        public int Soluong()
        {
            int soluong = 0;
            List<GioHang> lstGioHang = LayGioHang();
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

    }
}
