using CoronaData.Models;
using CoronaData.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaServices
{
    public class LocatieService
    {
        private readonly ILocatieRepository locatieRepository;
        public LocatieService(ILocatieRepository locatieRepository)
        {
            this.locatieRepository = locatieRepository;
        }
        public async Task<Locatie> GetLocatie(int id)
        {
            return await locatieRepository.GetLocatie(id);
        }

        public async Task<List<Locatie>> GetAllLocatiesByKlantId(int id)
        {
            return await locatieRepository.GetAllLocatiesForKlant(id);
        }

        public async Task<Locatie> GetLocatieByAdresAndNaam(Adres adres, string naam)
        {
            return await locatieRepository.GetLocatieByAdresAndNaam(adres, naam);
        }

        public void VoegLocatieToe(Locatie locatie)
        {
            locatieRepository.Add(locatie);
        }

        public void VerwijderLocatie(Locatie locatie)
        {
            locatieRepository.Remove(locatie);
        }

        public async Task<List<Locatie>> GetLocatiesMetBesmettingsgevaar(DateTime van, DateTime tot)
        {
           return await locatieRepository.GetAllLocatiesByBesmettingsgevaar(van, tot);
        }

    }
}
