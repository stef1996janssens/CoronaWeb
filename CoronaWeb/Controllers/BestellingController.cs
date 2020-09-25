using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaData.Models;
using CoronaServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoronaWeb.Controllers
{
    [Authorize]
    public class BestellingController : Controller
    {
        private readonly KlantService klantService;
        private readonly BestellingService bestellingService;
        public BestellingController (KlantService klantService, BestellingService bestellingService)
        {
            this.klantService = klantService;
            this.bestellingService = bestellingService;
        }
        public async Task<IActionResult> BestellingPlaatsen()
        {
            var mandje = new Mandje();
            var sessionAlsString = HttpContext.Session.GetString("gevuldMandje");
            mandje = JsonConvert.DeserializeObject<Mandje>(sessionAlsString);

            
             
            var userMail = User.Identity.Name;
            Klant klant = await klantService.GetKlantByMail(userMail);
            
                       
            var bestelling = new Bestelling
            {
                KlantId = klant.Klantnr,
                Bestellijnen = mandje.Bestellijnen 
            };

            bestellingService.BestellingToevoegen(bestelling);
            
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
            
        }
    }
}
