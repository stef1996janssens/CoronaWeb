using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaData.Models
{
    public class Adres
    {
        public int Id { get; set; }
        public int GemeenteId { get; set; }
        public string Straatnaam { get; set; }
        public string  Huisnr { get; set; }
        public string Bus { get; set; }
        public Gemeente Gemeente { get; set; }
    }
}
