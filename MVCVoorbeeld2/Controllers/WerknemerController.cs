using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCVoorbeeld2.Controllers
{
    public class WerknemerController : Controller
    {
        

        // GET: Werknemer
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult Palindroom(string woord)
        {
            char[] omgekeerd = woord.ToCharArray();
            Array.Reverse(omgekeerd);
            string Achtersteveuren = new string(omgekeerd);

            if(woord == Achtersteveuren)
            {
                ViewBag.palindroom = true;
            }
            else
            {
                ViewBag.palindroom = false;
            }

            ViewBag.ingetiktwoord = woord;

            return View();
        }
    }
}