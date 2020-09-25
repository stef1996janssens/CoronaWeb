using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaData.Models;
using CoronaServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoronaWeb.Controllers
{
    [Route("mandje")]
    [ApiController]
    public class MandjeController : ControllerBase
    {
        private readonly ProductService productService;
        public MandjeController(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost("plus/{id}")]
        //[HttpPost("{id}")]
        public void VerhoogAantal(int id)
        {
            Dictionary<int, int> mandje;
            
            var sessionAlsString = HttpContext.Session.GetString("mandje");
            if (sessionAlsString == null)
            {
                mandje = new Dictionary<int, int>();
            }
            else
            {
                mandje =  JsonConvert.DeserializeObject<Dictionary<int, int>>(sessionAlsString);
            }

            if (mandje.ContainsKey(id))
            {
                mandje[id]++;
            }
            else
            {
                mandje[id] = 1;
            }
            HttpContext.Session.SetString("mandje", JsonConvert.SerializeObject(mandje));
        }

        [HttpPost("min/{id}")]
        public void VerlaagAantal(int id)
        {
            Dictionary<int, int> mandje;
            var sessionAlsString =  HttpContext.Session.GetString("mandje");
            mandje = JsonConvert.DeserializeObject<Dictionary<int, int>>(sessionAlsString);
            mandje[id]--;
            HttpContext.Session.SetString("mandje", JsonConvert.SerializeObject(mandje));
        }
        
    }
}
