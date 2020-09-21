using CoronaData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaData.Repositories
{
    public class SQLKlantRepository : IKlantRepository
    {
        private  readonly CoronaDataContext context;
       
        public SQLKlantRepository (CoronaDataContext context)
        {
            this.context = context;
        }
        public void Add(Klant klant)
        {
            context.Klanten.Add(klant);
            context.SaveChanges();
        }

        public Task<Klant> GetKlantById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Klant>> GetKlantByEmail(string email)
        {
            return await context.Klanten
                .Where(klant => klant.Email == email)
                .ToListAsync();
        }

        
    }
}
