using CoronaData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaData.Repositories
{
    public interface IBestellingRepository
    {
        void Add(Bestelling bestelling);
    }
}
