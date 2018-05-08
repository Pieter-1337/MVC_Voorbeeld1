using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Voorbeeld3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            String resultaat = "Dit is jouw eerste bezoek";

            //Ondersteunt de browser cookies?
            if(Request.Cookies != null)
            {
                //Is er een cookie met de naam lastvisit?
                if(Request.Cookies["lastvisit"] != null)
                {
                    //dan lezen we het tijdstip van het laatste bezoek uit de cookie
                    resultaat = "Welkom terug jouw laatste bezoek was op " + Request.Cookies["lastvisit"]["tijdstip"] + ". Jouw voorkeurtaal is " + Request.Cookies["lastvisit"]["taal"] + ".";
                                
                }
                
                //We slaan het huidige tijdstip op als het laatste bezoek
                string laatsteBezoek = DateTime.Now.ToString();
                var usercookie = new HttpCookie("lastvisit");
                usercookie["tijdstip"] = laatsteBezoek;
                usercookie["taal"] = Request.UserLanguages[0];
                usercookie.Expires = DateTime.Now.AddDays(365);
                Response.Cookies.Add(usercookie);
            }

            ViewBag.Tijdstip = resultaat;
            return View();
        }

        public ActionResult Wissen()
        {
            //Ondersteunt de browser cookies?
            if(Request.Cookies != null)
            {
                //Is er een cookie me de naam lastvisit?
                if(Request.Cookies["lastvisit"] != null)
                {
                    //Set de expiry date op gisteren zodoende wordt de cookie meteen verwijderd
                    Request.Cookies["lastvisit"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(Request.Cookies["lastvisit"]);

                }
            }
            return View();
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