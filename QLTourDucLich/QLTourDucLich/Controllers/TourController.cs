using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTourDucLich.Models;
using PagedList;
using PagedList.Mvc;

namespace QLTourDucLich.Controllers
{
    public class TourController : Controller
    {
        //
        // GET: /Tour/
        QlTourDuLichEntities ql = new QlTourDuLichEntities();
        
      

        public ViewResult ChiTietTour(string matour)
        {

            ChiTietT tour = new ChiTietT(matour);
            List<ChiTietT> listtour = new List<ChiTietT>();
            listtour.Add(tour);
            return View(listtour);
        }
              

    }
}
