using CoronaData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaData.Repositories
{
    public class SQLAdresRepository : IAdresRepository
    {
        private readonly CoronaDataContext context;
        public SQLAdresRepository(CoronaDataContext context)
        {
            this.context = context;
        }

        public async Task<List<Adres>> GetAdresAdressenVolgensIds(List<int> ids)
        {
            return await context.Adressen.Where(adres => ids.Contains(adres.Id)).ToListAsync();
        }

        public async Task<Adres> GetAdresByStraatAndHuisnrAndBusAndGemeenteAndPostcode(string straat, string huisnr, string bus, string gemeenteNaam, string postcode)
        {
            return await context.Adressen.Where(
                adres => adres.Straatnaam.ToUpper() == straat.ToUpper() &&
                adres.Huisnr.ToUpper() == huisnr.ToUpper() &&
                adres.Bus.ToUpper() == bus.ToUpper() &&
                adres.Gemeente.Naam.ToUpper() == gemeenteNaam.ToUpper() &&
                adres.Gemeente.Postcode == postcode).FirstOrDefaultAsync();
        }
        public async Task<Adres> GetAdresByStraatAndHuisnrAndGemeenteAndPostcode(string straat, string huisnr, string gemeenteNaam, string postcode)
        {
            return await context.Adressen.Where(
                adres => adres.Straatnaam.ToUpper() == straat.ToUpper() &&
                adres.Huisnr.ToUpper() == huisnr.ToUpper() &&
                adres.Gemeente.Naam.ToUpper() == gemeenteNaam.ToUpper() &&
                adres.Gemeente.Postcode == postcode).FirstOrDefaultAsync();
        }

        public async Task<List<Adres>> GetAllAdressen()
        {
            return await context.Adressen.ToListAsync(); 
        }
    }
}
