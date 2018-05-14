using MVC_Voorbeeld3.Models;
using MVC_Voorbeeld3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}