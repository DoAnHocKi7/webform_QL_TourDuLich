using QLTourDucLich.Areas.QuanTriVien.ViewModel;
using QLTourDucLich.Areas.QuanTriVien.ViewModel.Tour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTourDucLich.Areas.QuanTriVien.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /QuanTriVien/Admin/
        public ActionResult Index()
        {
            ThaoTacTourViewModel model = new ThaoTacTourViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ThaoTacTourViewModel model)
        {
            return View(model);
        }

        public ActionResult Login(LoginViewModel model)
        {

            return View(model);
        }

    }
}
