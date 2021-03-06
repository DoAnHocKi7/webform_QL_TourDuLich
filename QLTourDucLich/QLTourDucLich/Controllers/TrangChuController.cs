﻿using QLTourDucLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using QLTourDucLich.ViewModel.Tour;
using QLTourDucLich.Areas.QuanTriVien.Queries.TourDuLich;
using QLTourDucLich.Queries.Tour;

namespace QLTourDucLich.Controllers
{
    public class TrangChuController : Controller
    {
        //
        // GET: /TrangChu/
        public ActionResult Index(int? page)
        {
            int pageSize = 8;

            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.Tours = TourQueries.LoadDSTour().ToPagedList(pageIndex, pageSize);

            ViewBag.MaDiaDiemDi = DiaDiemQueries.LoadDiaDiem(); ;
            ViewBag.MaDiaDiemDen = DiaDiemQueries.TimDiemDen2(int.Parse(ViewBag.MaDiaDiemDi.SelectedValue.ToString()));

            //List<string> lst = new List<string>();
            //lst = TourQueries.Loc_CollaborativeFiltering("1885", "15", 9);


            return View(new TimKiemTourViewModel());
        }


    }
}
