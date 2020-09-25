using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaData.Models;
using CoronaServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace CoronaWeb.Controllers
{
    [Authorize]
    public class LocatieController : Controller
    {
        private readonly AdresService adresService;
        private readonly GemeenteService gemeenteService;
        private readonly LocatieService locatieService;
        private readonly KlantService klantService;
        public LocatieController(AdresService adresService, GemeenteService gemeenteService, LocatieService locatieService, KlantService klantService)
        {
            this.adresService = adresService;
            this.gemeenteService = gemeenteService;
            this.locatieService = locatieService;
            this.klantService = klantService;
        }
        public async Task<IActionResult> Index(Locatie form)
        {
            return View(form);
        }


        [HttpPost]
        public async Task<IActionResult> LocatieToevoegen(Locatie form)
        {
            if (this.ModelState.IsValid)
            {
                var userMail = User.Identity.Name;
                Klant klant = await klantService.GetKlantByMail(userMail);
                ViewBag.VanTot = "";

                //CONTROLE OF VAN < TOT
                if (form.Van >= form.Tot)
                {
                    ViewBag.VanTot = "Van kan niet groter zijn dan Tot, pas de datums aan!";
                    return View("Index", form); 
                }

                //CONTROLE OF GEMEENTE AL BESTAAT, ANDERS GEMEENTE TOEVOEGEN
                var gemeente = new Gemeente();
                Gemeente alGekendeGemeente = await gemeenteService.GetGemeenteByNameAndPostcode(form.Adres.Gemeente.Naam, form.Adres.Gemeente.Postcode);
                if (alGekendeGemeente != null)
                {
                    gemeente = alGekendeGemeente;
                }
                else
                {
                    gemeente = new Gemeente
                    {
                        Naam = form.Adres.Gemeente.Naam,
                        Postcode = form.Adres.Gemeente.Postcode
                    };
                }

                //CONTROLE OF ADRES AL BESTAAT, ANDERS ADRES TOEVOEGEN
                var adres = new Adres();
                Adres alGekendAdres = new Adres();
                if (form.Adres.Bus == null)
                {
                    alGekendAdres = await adresService.GetAdresByStraatAndHuisnrAndGemeenteAndPostcode(form.Adres.Straatnaam, form.Adres.Huisnr, form.Adres.Gemeente.Naam, form.Adres.Gemeente.Postcode);
                }
                else
                {
                    alGekendAdres = await adresService.GetAdresByStraatAndHuisnrAndBusAndGemeenteAndPostcode(form.Adres.Straatnaam, form.Adres.Huisnr, form.Adres.Bus, form.Adres.Gemeente.Naam, form.Adres.Gemeente.Postcode);
                }
                if (alGekendAdres != null)
                {
                    adres = alGekendAdres;
                }
                else
                {
                    adres = new Adres
                    {
                        Straatnaam = form.Adres.Straatnaam,
                        Huisnr = form.Adres.Huisnr,
                        Bus = form.Adres.Bus,
                        Gemeente = gemeente
                    };
                }

                //LOCATIE TOEVOEGEN AAN DATABASE
                var locatie = new Locatie
                {
                    Naam = form.Naam,
                    Adres = adres,
                    KlantId = klant.Klantnr,
                    Van = form.Van,
                    Tot = form.Tot
                    
                };
                locatieService.VoegLocatieToe(locatie);
            }
            return View("Index", form);
        }

        public async Task<IActionResult> BekijkLocatieLijst()
        {
            
            var userMail = User.Identity.Name;
            Klant klant = await klantService.GetKlantByMail(userMail);

            List<Locatie> locaties = await locatieService.GetAllLocatiesByKlantId(klant.Klantnr);
            

            return View(locaties);
        }

        public async Task<IActionResult> VerwijderLocatie(int id)
        {
            var userMail = User.Identity.Name;
            Klant klant = await klantService.GetKlantByMail(userMail);
            Locatie locatie = await locatieService.GetLocatie(id);

            locatieService.VerwijderLocatie(locatie);

            List<Locatie> locaties = await locatieService.GetAllLocatiesByKlantId(klant.Klantnr);
            return View("BekijkLocatieLijst", locaties);

            

            

        }
    }
}
