using CoronaData.Models;
using CoronaData.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaServices
{
    public class AdresService 
    {
        private readonly IAdresRepository adresRepository;
        public AdresService(IAdresRepository adresRepository)
        {
            this.adresRepository = adresRepository;
        }

        public async Task<List<Adres>> GetAdresAdressenVolgensIds(List<int> ids)
        {
            return await adresRepository.GetAdresAdressenVolgensIds(ids);
        }

        public async Task<List<Adres>> GetAllAdressen()
        {
            return await adresRepository.GetAllAdressen();
        }

        public async Task<Adres> GetAdresByStraatAndHuisnrAndBusAndGemeenteAndPostcode(string straat, string huisnr, string bus, string gemeenteNaam, string postcode)
        {
            return await adresRepository.GetAdresByStraatAndHuisnrAndBusAndGemeenteAndPostcode(straat, huisnr, bus, gemeenteNaam, postcode);
        }
        public async Task<Adres> GetAdresByStraatAndHuisnrAndGemeenteAndPostcode(string straat, string huisnr, string gemeenteNaam, string postcode)
        {
            return await adresRepository.GetAdresByStraatAndHuisnrAndGemeenteAndPostcode(straat, huisnr, gemeenteNaam, postcode);
        }
    }
}
