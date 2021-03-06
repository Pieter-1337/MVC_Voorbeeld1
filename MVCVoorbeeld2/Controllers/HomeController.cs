﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCVoorbeeld2.Models;

namespace MVCVoorbeeld2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Persoon {Voornaam = "Eddy", Familienaam = "Wally" });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}