using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTourDucLich.Models;
using QLTourDucLich.Queries.GioHang;
using QLTourDucLich.Queries.NguoiDung;
using QLTourDucLich.Queries.Tour;
using QLTourDucLich.ViewModel.Tour;
using Rotativa;

namespace QLTourDucLich.Controllers
{
    public class GioHangController : Controller
    {
        public static List<SPDaMua> GIOHANG;

        public static KHACHHANG CUSOTMER;
        //
        // GET: /GioHang/
        QlTourDuLichEntities ql = new QlTourDuLichEntities();
        public ActionResult Index()
        {
            return View();
        }
        #region Gio Hang


        // vừa vào cứ bắt sự kiện thêm vào giỏ hàng chạy trước
        public ActionResult ThemGioHang(string matour)
        {
            if (Session[Constants.Constants.TOURDADAT]!=null)
            {
                Session[Constants.Constants.TOURDADAT] = matour;
            }
            else
            {
                Response.Write("Sản Phẩm Đã Tồn Tại Trong Giỏ Hàng");
                // return Redirect(strURL);
            }
            return RedirectToAction("GioHang");
        }

        // Cập nhập số lượng giỏ hàng
        public ActionResult CapNhapGioHang(string matour, FormCollection f)
        {
            //SPDaMua sanpham = lstGioHang.SingleOrDefault(t => t.matour == matour);
            //if (sanpham != null)
            //{
            //    sanpham.slnguoilon = int.Parse(f["songuoilon"].ToString());
            //    sanpham.sltreem = int.Parse(f["sotreem"].ToString());

            //}
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaGioHang(string matour)
        {

            //SPDaMua sanpham = lstGioHang.SingleOrDefault(t => t.matour == matour);
            //if (sanpham != null)
            //{
            //    lstGioHang.RemoveAll(t => t.matour == matour);

            //}
            //if (lstGioHang.Count == 0)
            //{
            //    RedirectToAction("Index", "TrangChu");
            //}
            return RedirectToAction("GioHang");

        }

        public ActionResult GioHang()
        {
            if (Session[Constants.Constants.TOURDADAT] == null)
            {
                RedirectToAction("Index", "TrangChu");
            }
            string maTour = Session[Constants.Constants.TOURDADAT].ToString();
            TourChiTietViewModel tour = TourQueries.TimTour(maTour);
            return View(tour);
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
            List<SPDaMua> lstGioHang = Session["GioHang"] as List<SPDaMua>;
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
        // sử dụng được cho tất cả các hàm
        HOPDONG hd;
        public ActionResult DatHang(FormCollection f)
        {

            try
            {
                Random rd = new Random();
                int ma = rd.Next(2000);
                hd = new HOPDONG();
                // nếu vào hàm try khởi tạo thì giá trị chỉ chạy trong vòng try
                KHACHHANG kh = new KHACHHANG();
                kh.MaKH = ma.ToString();
                kh.TenKH = f["customer_name"].ToString();
                kh.SDTKH = f["customer_phone"].ToString();
                kh.Email = f["customer_email"].ToString();
                kh.DCKH = f["customer_address"].ToString();
                ql.KHACHHANGs.Add(kh);
                ql.SaveChanges();
                hd.MaHD = rd.Next(2000).ToString();
                hd.MaKH = kh.MaKH;
                hd.ThoiGianDat = DateTime.Now;
                hd.TongTien = TongTien();
                ql.HOPDONGs.Add(hd);
                ql.SaveChanges();
                //foreach (var item in spdm)
                //{
                //    ChiTietHopDong ctHD = new ChiTietHopDong();
                //    ctHD.MaCT_HopDong = rd.Next(2000).ToString();
                //    ctHD.MaHopDong = hd.MaHD;
                //    ctHD.MaTour = item.matour;
                //    ctHD.SLNguoiLon = item.slnguoilon;
                //    ctHD.SLTreEm = item.sltreem;
                //    ctHD.ThanhTien = item.thanhtien;
                //    ql.ChiTietHopDongs.Add(ctHD);
                //}
                //ql.SaveChanges();

                Session.Remove("GioHang");
            }
            catch
            {

            }
            return View(hd);
        }

        public ActionResult DaCoThongTin()
        {
            try
            {
                Random rd = new Random();
                int ma = rd.Next(2000);

                hd = new HOPDONG();

                // nếu vào hàm try khởi tạo thì giá trị chỉ chạy trong vòng try
                KHACHHANG kh = (KHACHHANG)Session["Login"];
                CUSOTMER = kh;


                hd.MaHD = rd.Next(2000).ToString();
                hd.MaKH = kh.MaKH;
                hd.ThoiGianDat = DateTime.Now;
                hd.TongTien = TongTien() - (TongTien() * Convert.ToDecimal(0.05));
                ql.HOPDONGs.Add(hd);
                ql.SaveChanges();
                //foreach (var item in spdm)
                //{
                //    ChiTietHopDong ctHD = new ChiTietHopDong();
                //    ctHD.MaCT_HopDong = rd.Next(2000).ToString();
                //    ctHD.MaHopDong = hd.MaHD;
                //    ctHD.MaTour = item.matour;
                //    ctHD.SLNguoiLon = item.slnguoilon;
                //    ctHD.SLTreEm = item.sltreem;
                //    ctHD.ThanhTien = item.thanhtien;
                //    ql.ChiTietHopDongs.Add(ctHD);
                //}
                ql.SaveChanges();
                Session.Remove("GioHang");
            }
            catch
            {

            }
            return View(hd);
        }
        #endregion

        public ActionResult XemHoaDon()
        {
            ViewBag.KhachHang = CUSOTMER;
            return View(GIOHANG);
        }

        public ActionResult InHoaDonPDF()
        {
            return new Rotativa.ActionAsPdf("XemHoaDon");
        }

        public ActionResult TraCuuDonHang()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TraCuuDonHang(string maHopDong)
        {
            if (maHopDong != null)
            {
                ViewBag.KhachHangDat = KhachHangQueries.TimKhachHang(maHopDong);
                ViewBag.TimKiemHopDong = HopDongQueries.TimHopDong(maHopDong);
            }
            return View();
        }
    }
}
