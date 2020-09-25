using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    public class WebshopController : Controller
    {
        private readonly ProductService productService;
        private readonly SoortService soortService;
        public WebshopController(ProductService productService, SoortService soortService)
        {
            this.productService = productService;
            this.soortService = soortService;
        }
        public async Task<IActionResult> Index(WebshopViewModel model)
        {
            model.Soorten = (ICollection<Soort>)await soortService.GetAllSoorten();
            model.Producten = new List<Product>();


            return View(model);
        }

        public async Task<IActionResult> KiesSoort(int id)
        {
            var soort = await soortService.GetSoort(id);
            var soorten = await soortService.GetAllSoorten();
            var productAantallen = new Dictionary<int, int>();

            var producten = await productService.GetAllProductsBySoortId(id);

            var sessionAlsString = HttpContext.Session.GetString("mandje");
            if (sessionAlsString == null)
            {
                productAantallen = new Dictionary<int, int>();
            }
            else
            {
                productAantallen =  JsonConvert.DeserializeObject<Dictionary<int, int>>(sessionAlsString);
            }

            foreach(var product in producten)
            {
                foreach (var item in productAantallen)
                {
                    if (product.Id == item.Key)
                    {
                        product.Aantal = item.Value;
                    }
                }
            }

            var model = new WebshopViewModel
            {
                Id = soort.Id,
                Producten = producten,
                Soorten = soorten.ToList(),
                
            };

            return View("Index", model);
        }
    }
}


