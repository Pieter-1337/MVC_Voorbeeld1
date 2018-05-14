using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Voorbeeld3.Services;

namespace MVC_Voorbeeld3.Controllers
{
    public class FiliaalController : Controller
    {
        private FiliaalService filiaalService = new FiliaalService();
        private HoofdZetelService hoofdZetelService = new HoofdZetelService();
        

        // GET: Filiaal
        public ActionResult Index()
        {
            var hoofdZetel = hoofdZetelService.Read();
            ViewBag.hoofdZetel = hoofdZetel;

            var filialen = filiaalService.FindAll();

            return View(filialen);
        }


        public ActionResult Verwijderen(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var filiaal = filiaalService.Read((int)id);
            return View(filiaal);
        }

        [HttpPost]
        public ActionResult Verwijderen(int id)
        {
            filiaalService.Delete((int)id);
            TempData["Message"] = "Filiaal is succesvol verwijderd!";
            return RedirectToAction("Index");
        }
    }
}