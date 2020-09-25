using CoronaData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaData.Repositories
{
    public class SQLSoortRepository : ISoortRepository
    {
        private readonly CoronaDataContext context;
        public SQLSoortRepository(CoronaDataContext context)
        {
            this.context = context;
        }
        public async Task<List<Soort>> GetAllSoorten()
        {
            return await context.Soorten.OrderBy(type => type.Naam).ToListAsync();
        }

        public async Task<Soort> GetSoort(int id)
        {
            return await context.Soorten.FindAsync(id);
        }
    }
}
