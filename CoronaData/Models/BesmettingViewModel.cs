using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaData.Models
{
    public class BesmettingViewModel
    {
        public virtual Klant Klant { get; set; }
        public List<Locatie> LocatiesMetBesmettingsGevaar { get; set; }
    }
}
