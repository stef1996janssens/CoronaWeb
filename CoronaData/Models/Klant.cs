using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaData.Models
{
    public class Klant
    {
        public string UserName { get; set; }

        public string Email { get; set; }
        public int Klantnr { get; set; }
        [Required(ErrorMessage = "dit veld is verplicht in te vullen")]
        public string Familienaam { get; set; }
        [Required(ErrorMessage = "dit veld is verplicht in te vullen")]
        public string Voornaam { get; set; }

        public string Telefoonnr { get; set; }
        [Required(ErrorMessage = "dit veld is verplicht in te vullen")]
        public string Gsmnr { get; set; }
        public virtual Adres Adres { get; set; }
        public virtual ICollection<Bestelling> Bestellingen { get; set; } = new List<Bestelling>();
    }
}
