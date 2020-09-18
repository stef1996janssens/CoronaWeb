using CoronaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaData.Models
{
    public class Bestelling
    {
        public int Id { get; set; }
        public int KlantId { get; set; }
        public virtual Klant Klant { get; set; }
        public virtual ICollection<Bestellijn> Bestellijnen { get; set; } = new List<Bestellijn>();
    }
}
