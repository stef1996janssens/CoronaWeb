using CoronaData.Models;
using CoronaData.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaServices
{
    public class SoortService
    {
        private readonly ISoortRepository soortRepository;
        public SoortService(ISoortRepository soortRepository)
        {
            this.soortRepository = soortRepository;
        }

        public async Task<List<Soort>> GetAllSoorten()
        {
            return await soortRepository.GetAllSoorten();
        }

        public async Task<Soort> GetSoort(int id)
        {
            return await soortRepository.GetSoort(id);
        }
    }
}
