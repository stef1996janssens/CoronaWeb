using CoronaData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaData.Repositories
{
    public interface IKlantRepository
    {
        void Add(Klant klant);

        Task<Klant> GetKlantById(int id);
        Task<List<Klant>> GetKlantByEmail(string email);
    }
}
