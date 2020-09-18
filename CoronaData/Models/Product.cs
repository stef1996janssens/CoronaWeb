using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaData.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        public Type Type { get; set; }

        public virtual ICollection<Bestellijn> Bestellijnen { get; set; } = new List<Bestellijn>();
    }
}
