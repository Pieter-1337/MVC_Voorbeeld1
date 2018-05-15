using MVC_Voorbeeld3.Models;
using MVC_Voorbeeld3.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_Voorbeeld3.Controllers
{
    public class PersoonController : Controller
    {
        private PersoonService persoonService = new PersoonService();

        // GET: Persoon
        public ActionResult Index()
        {
            List<Persoon> personen = persoonService.FindAll();
            return View(personen);
        }

        public ActionResult Verwijder(int? id)
        {
            Persoon persoon = persoonService.FindByID((int)id);
            return View(persoon);
        }

        [HttpPost]
        public ActionResult Verwijder(int id)
        {
            persoonService.Delete(id);
            TempData["Message"] = "Persoon werd verwijderd";
            return RedirectToAction("Index");
        }

        public ActionResult Toevoegen()
        {
            Persoon persoon = new Persoon()
            {
                Geslacht = Geslacht.Vrouw,//Default waarde voor deze enum wordt zo ingesteld
                Geboren = DateTime.Today
            };

            return View(persoon);
        }

        [HttpPost]
        public ActionResult Toevoegen(Persoon persoon)
        {
            if (this.ModelState.IsValid)
            {
                persoonService.Add(persoon);
                TempData["Message"] = persoon.Voornaam + ' ' + persoon.Familienaam + "werd toegevoegd";
                return RedirectToAction("Index");
            }
            else
            {
                return View(persoon);
            }
        }

        public ActionResult Wijzigen(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Persoon persoon = persoonService.FindByID((int)id);
            return View(persoon);
        }

        [HttpPost]
        public ActionResult Wijzigen(Persoon persoon)
        {
            if (this.ModelState.IsValid)
            {
                persoonService.Edit(persoon);
                TempData["Message"] = persoon.Voornaam + ' ' + persoon.Familienaam + " zijn gegevens werden gewijzigd en opgeslagen.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(persoon);
            }
        }

        public JsonResult ValidateDOB(string Geboren)
        {
            DateTime parsedDOB;
            if(!DateTime.TryParseExact(Geboren, "{0:d}", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDOB))
            {
                return Json("Gelieve een geldige datum in te voeren (m/d/jjjj)! ", JsonRequestBehavior.AllowGet);
            }
            else if((DateTime.Now.Year - parsedDOB.Year) >= 18)
            {
                return Json("Minimum leeft bedraagt 18 jaar", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}