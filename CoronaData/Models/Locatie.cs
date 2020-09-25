using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoronaData.Models
{
    public class Locatie
    {
       
        public int KlantId { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "dit veld is verplicht in te vullen")]
        public string Naam { get; set; }
        public int AdresId { get; set; }
        public Adres Adres { get; set; }
        [Required(ErrorMessage = "dit veld is verplicht in te vullen")]
        
        [DataType(DataType.DateTime)]
        public DateTime Van { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Tot { get; set; }
        public bool Besmetting { get; set; }
        
    }
}
