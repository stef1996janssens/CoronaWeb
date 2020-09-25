using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaData.Models
{
    public class LocatieViewModel
    {
        public string Naam { get; set; }
        public string Straat { get; set; }
        public string Huisnr { get; set; }
        public string Bus { get; set; }
        public string Gemeente { get; set; }
        public string Postcode { get; set; }
        public DateTime Tijdstip { get; set; }
    }
}
