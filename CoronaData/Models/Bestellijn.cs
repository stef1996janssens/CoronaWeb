using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaData.Models
{
    public class Bestellijn
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Aantal { get; set; }
        public decimal Waarde 
        { 

            get
            {
                return Prijs * Aantal;
            } 
        }
        private decimal prijsValue;
        public decimal Prijs
        {
            get
            {
                return prijsValue;
            }
            set
            {
                prijsValue = Product.Prijs;
            }
        }
        // Prijs property maken die 1 maal de prijs uit product lees bij het aanmaken van een nieuwe bestellijn.
        public virtual Product Product { get; set; }
        public virtual Bestelling Bestelling { get; set; }
    }
}
