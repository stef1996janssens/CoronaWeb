using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoronaData.Models
{
    public class Gemeente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "dit veld is verplicht in te vullen")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "dit veld is verplicht in te vullen")]
        public string Postcode { get; set; }

        public virtual ICollection<Adres> Adressen { get; set; } = new List<Adres>();
    }
}
