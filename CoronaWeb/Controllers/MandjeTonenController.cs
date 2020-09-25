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
    public class MandjeTonenController : Controller
    {
        private readonly ProductService productService;
        public MandjeTonenController(ProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            Mandje mandje = new Mandje();
            List<int> ids = new List<int>();
            mandje.Bestellijnen = new List<Bestellijn>();
            
            Dictionary<int, int> productAantallen;
            var sessionAlsString = HttpContext.Session.GetString("mandje"); 
            if (sessionAlsString == null)
            {
                productAantallen = new Dictionary<int, int>();
            }
            else
            {
                productAantallen = JsonConvert.DeserializeObject<Dictionary<int, int>>(sessionAlsString);
            }
            foreach (var item in productAantallen)
            {
                ids.Add(item.Key);
            }
            Dictionary<int, Product> producten = await productService.GetProductsVoorMandje(ids);

           foreach (var item in productAantallen)
            {
                var product = producten[item.Key];
                mandje.Bestellijnen.Add(new Bestellijn { Aantal = item.Value, Prijs = product.Prijs, ProductId = product.Id, ProductNaam = product.Naam });
            }
            HttpContext.Session.SetString("gevuldMandje", JsonConvert.SerializeObject(mandje));

            return View(mandje);
        }
    }
}
