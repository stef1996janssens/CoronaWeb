using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoronaData.Models
{
    public class Mandje
    {
        public List<Bestellijn> Bestellijnen { get; set; }
        [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
        public decimal TotalePrijs
        {
            get
            {
                var totalePrijs = 0m;
                foreach (var bestellijn in Bestellijnen)
                    {
                        totalePrijs += bestellijn.Waarde;
                    }
                return totalePrijs;
            }
            set
            {
                
            }
        }
    }
}
