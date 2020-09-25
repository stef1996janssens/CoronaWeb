using CoronaData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaData.Repositories
{
    public class SQLBestellingRepository : IBestellingRepository
    {
        private readonly CoronaDataContext context;
        public SQLBestellingRepository(CoronaDataContext context)
        {
            this.context = context;
        }

        public void Add(Bestelling bestelling)
        {
            context.Bestellingen.Add(bestelling);
            context.SaveChanges();
        }
    }
}
