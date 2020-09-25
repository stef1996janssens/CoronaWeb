using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaData.Models
{
    public class Bestellijn
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [NotMapped]
        public string ProductNaam { get; set; }
        public int Aantal { get; set; }
        [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
        [NotMapped]
        public decimal Waarde 
        {
            get
            {
                return Prijs * Aantal;
            } 
        }
        [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
        public decimal Prijs{ get; set; }
        
        public virtual Product Product { get; set; }
        public virtual Bestelling Bestelling { get; set; }
    }
}
