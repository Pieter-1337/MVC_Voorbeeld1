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

            //Werken met cookies
            ///

            //String resultaat = "Dit is jouw eerste bezoek";

            ////Ondersteunt de browser cookies?
            //if(Request.Cookies != null)
            //{
            //    //Is er een cookie met de naam lastvisit?
            //    if(Request.Cookies["lastvisit"] != null)
            //    {
            //        //dan lezen we het tijdstip van het laatste bezoek uit de cookie
            //        resultaat = "Welkom terug jouw laatste bezoek was op " + Request.Cookies["lastvisit"]["tijdstip"] + ". Jouw voorkeurtaal is " + Request.Cookies["lastvisit"]["taal"] + ".";
                                
            //    }
                
            //    //We slaan het huidige tijdstip op als het laatste bezoek
            //    string laatsteBezoek = DateTime.Now.ToString();
            //    var usercookie = new HttpCookie("lastvisit");
            //    usercookie["tijdstip"] = laatsteBezoek;
            //    usercookie["taal"] = Request.UserLanguages[0];
            //    usercookie.Expires = DateTime.Now.AddDays(365);
            //    Response.Cookies.Add(usercookie);
            //}

            //ViewBag.Tijdstip = resultaat;

            //Werken met Session
            ///
            if(this.Session["aantalBezoeken"] == null)
            {
                this.Session["aantalBezoeken"] = 1;
            }
            else
            {
                this.Session["aantalBezoeken"] = (int)this.Session["aantalBezoeken"] + 1;
            }

            //Applicationvariabele aanpassen
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["aantalBezoeken"] = (int)System.Web.HttpContext.Current.Application["aantalBezoeken"] + 1;
            System.Web.HttpContext.Current.Application.UnLock();

            return View();
        }

        public ActionResult Wissen()
        {
            //Gebruik van Cookies
            ////
            ////Ondersteunt de browser cookies?
            //if(Request.Cookies != null)
            //{
            //    //Is er een cookie me de naam lastvisit?
            //    if(Request.Cookies["lastvisit"] != null)
            //    {
            //        //Set de expiry date op gisteren zodoende wordt de cookie meteen verwijderd
            //        Request.Cookies["lastvisit"].Expires = DateTime.Now.AddDays(-1);
            //        Response.Cookies.Add(Request.Cookies["lastvisit"]);

            //    }
            //}

            //Gebruik van Session
            if(this.Session["aantalBezoeken"] != null)
            {
                this.Session["aantalBezoeken"] = null;
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