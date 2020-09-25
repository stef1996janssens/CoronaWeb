using CoronaData.Models;
using CoronaData.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaServices
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await productRepository.GetAllProducts();
        }

        public async Task<List<Product>> GetAllProductsBySoortId(int soortId)
        {
            return await productRepository.GetAllProductsVolgensSoort(soortId);
        }

        public async Task<Product> GetProduct(int id)
        {
            return await productRepository.GetProduct(id);
        }

        public async Task<Dictionary<int, Product>> GetProductsVoorMandje(List<int> ids)
        {
            return await productRepository.GetProductsVoorMandje(ids);
        }
    }
}
