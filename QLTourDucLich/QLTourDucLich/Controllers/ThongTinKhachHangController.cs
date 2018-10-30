using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTourDucLich.Controllers
{
    public class ThongTinKhachHangController : Controller
    {
        //
        // GET: /ThongTinKhachHang/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NhapThongTin()
        {
            if (Session["GioHang"] == null)
            {
                //nếu sản phẩm không có gì chuyển hướng đến index trang chủ 
                return RedirectToAction("Index", "TrangChu");

            }
            else
            {
                return View();
            }
          
        }

    }
}
