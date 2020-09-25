using CoronaData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaData.Repositories
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly CoronaDataContext context;
        public SQLProductRepository(CoronaDataContext context)
        {
            this.context = context;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            return await context.Producten.OrderBy(product => product.Soort).ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsVolgensSoort(int soortId)
        {
            return await context.Producten.Where(product => product.SoortId == soortId).ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await context.Producten.FindAsync(id);
        }

        public async Task<Dictionary<int,Product>> GetProductsVoorMandje(List<int> ids)
        {
            List<Product> products= await context.Producten.Where(product => ids.Contains(product.Id)).ToListAsync();
            var dictionary = new Dictionary<int, Product>();
            foreach (var product in products)
            {
                dictionary.Add(product.Id, product);

            }
            return dictionary;


        }
    }
}
