using Newtonsoft.Json;
using QLTourDucLich.Areas.QuanTriVien.Queries.Thong_Ke;
using QLTourDucLich.Areas.QuanTriVien.ViewModel.ThongKe;
using QLTourDucLich.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QLTourDucLich.Areas.QuanTriVien.Controllers
{
    public class ThongKeController : Controller
    {
        //
        // GET: /QuanTriVien/ThongKe/

        public ActionResult Index()
        {
            List<ThongKeTheoTourViewModel> dataPoints = ThongKeQueries.LayDuLieuThongKe();
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View();
        }

        public ActionResult ThongKeTheoThoiGian()
        {
            FormThongKeViewModel model = new FormThongKeViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult ThongKeTheoThoiGian(DateTime time)
        {
            List<ThongKeTheoThoiGianViewModel> dataPoints = ThongKeQueries.ThongKeTheoTG(time.Month,time.Year);
            ViewBag.ThoiGian = time.Month + "/" + time.Year;
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View();
        }
    }
}
