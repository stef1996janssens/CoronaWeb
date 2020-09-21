using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaData.Models;
using CoronaServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace CoronaWeb.Controllers
{
    public class KlantController : Controller
    {
        private readonly KlantService klantService;
        private readonly UserManager<IdentityUser> userManager;

        public KlantController(KlantService klantService, UserManager<IdentityUser> userManager)
        {
            this.klantService = klantService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult klantGegevens(Klant klant)
        {
            var email = User.Identity.Name;
            var gevondenKlanten = klantService.GetKlantByEmail(email);
           
            return View();
        }

        public IActionResult klantGegevensToevoegen(Klant klant)
        {
            if (this.ModelState.IsValid)
            {
                var klant = klantService.ge
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("klantGegevens", klant);
            }
        }
    }
}
