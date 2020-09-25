using CoronaData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaData.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int id);
        Task<List<Product>> GetAllProducts();

        Task<List<Product>> GetAllProductsVolgensSoort(int soortId);
        Task<Dictionary<int,Product>> GetProductsVoorMandje(List<int> ids);
    }
}
