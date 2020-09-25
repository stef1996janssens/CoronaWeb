using CoronaData.Models;
using CoronaData.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaServices
{
    public class BestellingService
    {
        private readonly IBestellingRepository bestellingRepository;
        public BestellingService(IBestellingRepository bestellingRepository)
        {
            this.bestellingRepository = bestellingRepository;
        }

        public void BestellingToevoegen(Bestelling bestelling)
        {
            bestellingRepository.Add(bestelling); 
        }
    }
}
