using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCVoorbeeld2.Models;

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

        [ActionName("Lijst")]
        public ActionResult AlleWerknemers()
        {
            var werknemers = new List<Werknemer>();

            werknemers.Add(new Werknemer
            {
                Voornaam = "Steven",
                Wedde = 1000,
                InDienst = DateTime.Today
            });

            werknemers.Add(new Werknemer
            {
                Voornaam = "Prosper",
                Wedde = 1000,
                InDienst = DateTime.Today.AddDays(2)
            });

            return View("AlleWerknemers" ,werknemers);
        }
    }
}