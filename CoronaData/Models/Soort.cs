using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaData.Models
{
    public class Soort
    {
       public int Id { get; set; }
       public string Naam { get; set; }
       public virtual ICollection<Product> Producten { get; set; } = new List<Product>();
    }
}
