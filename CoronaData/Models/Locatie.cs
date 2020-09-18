using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaData.Models
{
    public class Locatie
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public Adres Adres { get; set; }
    }
}
