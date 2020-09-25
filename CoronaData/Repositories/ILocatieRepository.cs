using CoronaData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaData.Repositories
{
    public interface ILocatieRepository
    {
        Task<Locatie> GetLocatie(int id);
        Task<List<Locatie>> GetAllLocatiesForKlant(int id);
        Task<List<Locatie>> GetAllLocatiesByBesmettingsgevaar(DateTime van, DateTime tot);
        Task<Locatie> GetLocatieByAdresAndNaam(Adres adres, string naam);

        void Add(Locatie locatie);

        void Remove(Locatie locatie);
    }
}
