using CoronaData.Models;
using CoronaData.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaServices
{
    public class KlantService
    {
        private readonly IKlantRepository klantRepository;
        public KlantService (IKlantRepository klantRepository)
        {
            this.klantRepository = klantRepository;
        }

        
        public void VoegGegevensKlantToe(Klant form)
        {
            Klant klant = null;
            klant = new Klant
            {
                Familienaam = form.Familienaam,
                Voornaam = form.Voornaam,
                Adres = new Adres
                {
                    Straatnaam = form.Adres.Straatnaam,
                    Huisnr = form.Adres.Huisnr,
                    Bus = form.Adres.Bus,
                    Gemeente = new Gemeente
                    {
                        Naam = form.Adres.Gemeente.Naam,
                        Postcode = form.Adres.Gemeente.Postcode
                    }
                },
                Telefoonnr = form.Telefoonnr,
                Gsmnr = form.Gsmnr
            };

            klantRepository.Add(klant);

        }

        public async Task<List<Klant>> GetKlantByEmail(string email)
        {
            return await klantRepository.GetKlantByEmail(email);
        }
    }
}
