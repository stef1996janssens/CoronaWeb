using CoronaData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaData.Repositories
{
    public class SQLGemeenteRepository : IGemeenteRepository
    {
        private readonly CoronaDataContext context;

        public SQLGemeenteRepository(CoronaDataContext context)
        {
            this.context = context;
        }
        public async Task<Gemeente> GetGemeenteByName(string gemeenteNaam, string postcode)
        {
            return await context.Gemeenten.Where(gemeente => gemeente.Naam.ToUpper() == gemeenteNaam.ToUpper() && gemeente.Postcode == postcode).FirstOrDefaultAsync();
        }
    }
}
