using CoronaData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaData.Repositories
{
    public interface IAdresRepository
    {
        Task<List<Adres>> GetAllAdressen();

        Task<List<Adres>> GetAdresAdressenVolgensIds(List<int> ids);

        Task<Adres> GetAdresByStraatAndHuisnrAndBusAndGemeenteAndPostcode(string straat, string huisnr, string bus, string gemeenteNaam, string postcode);
        Task<Adres> GetAdresByStraatAndHuisnrAndGemeenteAndPostcode(string straat, string huisnr, string gemeenteNaam, string postcode);

    }
}
