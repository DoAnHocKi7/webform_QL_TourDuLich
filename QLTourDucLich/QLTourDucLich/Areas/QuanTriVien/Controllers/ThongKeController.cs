using Newtonsoft.Json;
using QLTourDucLich.Areas.QuanTriVien.Queries.Thong_Ke;
using QLTourDucLich.Areas.QuanTriVien.ViewModel.ThongKe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

    }
}
