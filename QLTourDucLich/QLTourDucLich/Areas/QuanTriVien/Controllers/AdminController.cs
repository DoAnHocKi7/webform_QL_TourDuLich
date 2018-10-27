using QLTourDucLich.Areas.QuanTriVien.Queries;
using QLTourDucLich.Areas.QuanTriVien.ViewModel;
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
            ChinhSuaTourViewModel model = new ChinhSuaTourViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ChinhSuaTourViewModel model)
        {
            return View(model);
        }

        public ActionResult Login(LoginViewModel model)
        {

            return View(model);
        }
    }
}
