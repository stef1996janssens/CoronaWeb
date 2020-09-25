using CoronaData.Models;
using CoronaData.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaServices
{
    public class GemeenteService
    {
        private readonly IGemeenteRepository gemeenteRepository;
        public GemeenteService(IGemeenteRepository gemeenteRepository)
        {
            this.gemeenteRepository = gemeenteRepository;
        }

        public async Task<Gemeente> GetGemeenteByNameAndPostcode(string gemeenteNaam, string postcode)
        {
            return await gemeenteRepository.GetGemeenteByName(gemeenteNaam, postcode);
        }
    }
}
