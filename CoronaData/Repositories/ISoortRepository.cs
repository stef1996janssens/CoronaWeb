
using CoronaData.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaData.Repositories
{
    public interface ISoortRepository
    {
        Task<Soort> GetSoort(int id);
        Task<List<Soort>> GetAllSoorten();
    }
}
