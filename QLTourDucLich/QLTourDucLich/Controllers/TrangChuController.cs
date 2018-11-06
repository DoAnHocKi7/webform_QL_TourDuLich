using QLTourDucLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace QLTourDucLich.Controllers
{
    public class TrangChuController : Controller
    {
        //
        // GET: /TrangChu/
        QlTourDuLichEntities ql = new QlTourDuLichEntities();
        public ActionResult Index(int? page)
        {
            int pageSize = 8;

            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;


            return View(ql.TOURs.ToList().OrderBy(t => t.GiaNguoiLon).ToPagedList(pageIndex, pageSize));
        }
        

    }
}
