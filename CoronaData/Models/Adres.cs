using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaData.Models
{
    public class Adres
    {
        public int Id { get; set; }
        public int GemeenteId { get; set; }
        [Required(ErrorMessage = "dit veld is verplicht in te vullen")]
        public string Straatnaam { get; set; }
        [Required(ErrorMessage = "dit veld is verplicht in te vullen")]
        public string  Huisnr { get; set; }
        public string Bus { get; set; }
        public Gemeente Gemeente { get; set; }
    }
}
