using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaData.Models
{
    public class Gemeente
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Postcode { get; set; }

        public virtual ICollection<Adres> Adressen { get; set; } = new List<Adres>();
    }
}
