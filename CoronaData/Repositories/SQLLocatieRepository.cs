using CoronaData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaData.Repositories
{
    public class SQLLocatieRepository : ILocatieRepository
    {
        private readonly CoronaDataContext context;
        public SQLLocatieRepository(CoronaDataContext context)
        {
            this.context = context;
        }

        public async Task<Locatie> GetLocatie(int id)
        {
           return await context.Locaties.FindAsync(id);
        }
        public async Task<List<Locatie>> GetAllLocatiesForKlant(int id)
        {
            return await context.Locaties.Include(locatie => locatie.Adres)
                .Include(locatie => locatie.Adres.Gemeente)
                .Where(locatie => locatie.KlantId == id).ToListAsync();
        }

        public async Task<Locatie> GetLocatieByAdresAndNaam(Adres adres, string naam)
        {
            return await context.Locaties.Where(locatie => locatie.Adres == adres && locatie.Naam == naam).FirstOrDefaultAsync();
        }

        public void Add(Locatie locatie)
        {
            context.Locaties.Add(locatie);
            context.SaveChanges();
        }

        public void Remove(Locatie locatie)
        {
            context.Locaties.Remove(locatie);
            context.SaveChanges();
        }

        public async Task<List<Locatie>> GetAllLocatiesByBesmettingsgevaar(DateTime Van, DateTime Tot)
        {
            return await context.Locaties.Where(locatie => locatie.Besmetting == true 
            && ((locatie.Van <= Van && locatie.Tot.AddHours(2) > Van) || (locatie.Van >= Van && locatie.Tot.AddHours(2) <= Tot) || (locatie.Van < Tot && locatie.Tot.AddHours(2) >= Tot))).ToListAsync();
        }
    }
}
