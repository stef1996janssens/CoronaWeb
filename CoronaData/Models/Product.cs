using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaData.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
        public decimal Prijs { get; set; }
        public int SoortId { get; set; }
        [NotMapped]
        public int Aantal { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual Soort Soort { get; set; }
        public virtual ICollection<Bestellijn> Bestellijnen { get; set; } = new List<Bestellijn>();
    }
}
