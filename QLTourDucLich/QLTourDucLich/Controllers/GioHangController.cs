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
        QlTourDuLichEntities ql = new QlTourDuLichEntities();
        public ActionResult Index()
        {
            return View();
        }
        #region Gio Hang
        // Lấy sản phẩm hiện tại có trong giỏ hàng
        public List<SPDaMua> LayGioHang()
        {
            //gán bằng cái list sao đó ép kiểu session về list 
            // ép về cái list để đếm số lượng sản phẩm trong mảng
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
          
            List<SPDaMua> lstGioHang = LayGioHang();
            // Kiểm tra hàng này đã tồn tại trong list chưa
            SPDaMua sanpham = lstGioHang.Find(t => t.matour == matour);
            if (sanpham == null)
            {
                sanpham = new SPDaMua(matour);
                lstGioHang.Add(sanpham);   
               

            }
            else
            {
                Response.Write("Sản Phẩm Đã Tồn Tại Trong Giỏ Hàng");
               // return Redirect(strURL);
            }

            return RedirectToAction("Index","TrangChu");

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
            if (lstGioHang.Count == 0)
            {
                RedirectToAction("Index", "TrangChu");
            }
            return RedirectToAction("GioHang");

        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "TrangChu");
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

                List<SPDaMua> spdm = LayGioHang();
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
                foreach (var item in spdm)
                {
                    ChiTietHopDong ctHD = new ChiTietHopDong();
                    ctHD.MaCT_HopDong = rd.Next(2000).ToString();
                    ctHD.MaHopDong = hd.MaHD;
                    ctHD.MaTour = item.matour;
                    ctHD.SLNguoiLon = item.slnguoilon;
                    ctHD.SLTreEm = item.sltreem;
                    ctHD.ThanhTien = item.thanhtien;
                    ql.ChiTietHopDongs.Add(ctHD);


                }
                ql.SaveChanges();
               
                spdm.Clear();
             
              

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

                List<SPDaMua> spdm = LayGioHang();
                // nếu vào hàm try khởi tạo thì giá trị chỉ chạy trong vòng try
                KHACHHANG kh = (KHACHHANG)Session["Login"];
               

                hd.MaHD = rd.Next(2000).ToString();
                hd.MaKH = kh.MaKH;
                hd.ThoiGianDat = DateTime.Now;
                hd.TongTien =TongTien()- (TongTien()*Convert.ToDecimal(0.05));
                ql.HOPDONGs.Add(hd);
                ql.SaveChanges();
                foreach (var item in spdm)
                {
                    ChiTietHopDong ctHD = new ChiTietHopDong();
                    ctHD.MaCT_HopDong = rd.Next(2000).ToString();
                    ctHD.MaHopDong = hd.MaHD;
                    ctHD.MaTour = item.matour;
                    ctHD.SLNguoiLon = item.slnguoilon;
                    ctHD.SLTreEm = item.sltreem;
                    ctHD.ThanhTien = item.thanhtien;
                    ql.ChiTietHopDongs.Add(ctHD);


                }
                ql.SaveChanges();

                spdm.Clear();



            }
            catch
            {

            }
            return View(hd);


        }
        #endregion
    }
}
