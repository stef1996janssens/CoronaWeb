using CoronaData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaData.Repositories
{
    public interface IGemeenteRepository
    {
        Task<Gemeente> GetGemeenteByName(string gemeenteNaam, string postcode);
    }
}
