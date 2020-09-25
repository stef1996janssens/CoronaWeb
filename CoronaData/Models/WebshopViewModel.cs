using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaData.Models
{
    public class WebshopViewModel
    {
        public int Id { get; set; }
        public int Naam { get; set; }
        public Dictionary<int, int> ProductAantallen { get; set; }
        public virtual ICollection<Product> Producten { get; set; }
        public virtual ICollection<Soort> Soorten { get; set; }
    }
}
