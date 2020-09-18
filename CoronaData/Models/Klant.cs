using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaData.Models
{
    public class Klant
    {
        public int Klantnr { get; set; }
        public string Familienaam { get; set; }
        public string Voornaam { get; set; }
        public string Telefoonnr { get; set; }
        public string Gsmnr { get; set; }
        public virtual Adres Adres { get; set; }
        public virtual ICollection<Bestelling> Bestellingen { get; set; } = new List<Bestelling>();
    }
}
