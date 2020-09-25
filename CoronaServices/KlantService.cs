using CoronaData.Models;
using CoronaData.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaServices
{
    public class KlantService
    {
        private readonly IKlantRepository klantRepository;
        public KlantService(IKlantRepository klantRepository)
        {
            this.klantRepository = klantRepository;
        }

        public async Task<Klant> GetKlant(int id)
        {
            return await klantRepository.GetKlantById(id);
        }

        public async Task<Klant> GetKlantByMail(string email)
        {
            return await klantRepository.GetKlantByMail(email);
        }

        public void update(Klant klant)
        {
            klantRepository.update(klant);
        }
    }
}
