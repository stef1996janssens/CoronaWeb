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

        public async Task<Klant> GetKlantById(int id)
        {
            return await context.Klanten.FindAsync(id);
        }

       public async Task<Klant> GetKlantByMail(string email)
        {
           return await context.Klanten.Where(klant => klant.Email == email).FirstOrDefaultAsync();
        }

        public void update(Klant klant)
        {
            context.SaveChanges();
        }
    }
}
