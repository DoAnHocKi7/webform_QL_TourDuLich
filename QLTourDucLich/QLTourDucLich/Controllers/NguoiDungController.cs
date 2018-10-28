using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTourDucLich.Models;
using QLTourDucLich.ViewModel;

namespace QLTourDucLich.Controllers
{
    public class NguoiDungController : Controller
    {
        //
        // GET: /NguoiDung/
        QlTourDuLichEntities ql = new QlTourDuLichEntities();
        public ActionResult NguoiDung()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
         
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KHACHHANGViewModel KH)
        {
            Random rd = new Random();
            KH.MaKH = rd.Next(1000).ToString();
            if (ModelState.IsValid)
            {


                try
                {
                    ql.KHACHHANGs.Add(KH);
                    ql.SaveChanges();
                }
                catch
                {

                }
             

            }
            
            return View();
        }

      
    }
}
