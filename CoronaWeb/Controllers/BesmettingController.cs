using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaData.Models;
using CoronaServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoronaWeb.Controllers
{
    [Authorize]
    public class BesmettingController : Controller
    {
        private readonly KlantService klantService;
        private readonly LocatieService locatieService;

        public BesmettingController(KlantService klantService, LocatieService locatieService)
        {
            this.klantService = klantService;
            this.locatieService = locatieService;

           
        }
        public async Task< IActionResult> Index(BesmettingViewModel form)
        {
            var userMail = User.Identity.Name;
            Klant klant = await klantService.GetKlantByMail(userMail);
            List < Locatie > locatiesKlant = await locatieService.GetAllLocatiesByKlantId(klant.Klantnr);
            List<List<Locatie>> alleLocatiesMetBesmettingsgevaar = new List<List<Locatie>>();

            var model = new BesmettingViewModel();
            model.LocatiesMetBesmettingsGevaar = new List<Locatie>();

            if(locatiesKlant != null)
            {
                foreach (var locatie in locatiesKlant)
                {
                    List<Locatie> locatiesMetBesmettingsGevaar = await locatieService.GetLocatiesMetBesmettingsgevaar(locatie.Van, locatie.Tot);
                    alleLocatiesMetBesmettingsgevaar.Add(locatiesMetBesmettingsGevaar);
                }

                foreach (var list in alleLocatiesMetBesmettingsgevaar)
                {
                    foreach (var locatie in list)
                    {
                        model.LocatiesMetBesmettingsGevaar.Add(locatie);
                    }
                }
            }
            

            


            //List < Locatie > locatiesKlant = await locatieService.GetAllLocatiesByKlantId(klant.Klantnr);
            //List<Locatie> locatiesMetBesmettingsGevaar = await locatieService.GetLocatiesMetBesmettingTrue();
            //List<Adres> locatiesKlantAdressen = new List<Adres>();
            //if(locatiesKlant.Count != 0)
            //{
            //    foreach (var locatie in locatiesKlant)
            //    {
            //        locatiesKlantAdressen.Add(locatie.Adres);
            //    }

            //    foreach (var locatie in locatiesMetBesmettingsGevaar)
            //    {
            //        if (locatiesKlantAdressen.Contains(locatie.Adres))
            //        {
            //            model.LocatiesMetBesmettingsGevaar.Add(locatie);
            //        }
            //    }
            //}
           

            return View(model);
        }

        public async Task< IActionResult> BesmettingAanpassen(BesmettingViewModel form)
        {

            var userMail = User.Identity.Name;
            Klant klant = await klantService.GetKlantByMail(userMail);
            List<Locatie> locatiesKlant = await locatieService.GetAllLocatiesByKlantId(klant.Klantnr);

            if (form.Klant.Besmet == true)
            {
                klant.Besmet = true;
                foreach(var locatie in locatiesKlant)
                {
                    if(DateTime.Now < (locatie.Van.AddDays(14)))
                    {
                        locatie.Besmetting = true;
                    }
                }
            }
            else
            {
                klant.Besmet = false;
            }
            klantService.update(klant);
            return RedirectToAction("Index");
        }
    }
}
