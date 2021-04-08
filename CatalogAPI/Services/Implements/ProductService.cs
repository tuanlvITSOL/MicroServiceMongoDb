using CatalogAPI.Entities;
using CatalogAPI.Repositories.Interfaces;
using CatalogAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogAPI.Services.Implements
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> AddProductAsync(Product obj)
        {
            return await _productRepository.Create(obj);

        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAllValues();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _productRepository.GetValueById(id);
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            return await _productRepository.GetProductByCategory(categoryName);
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await _productRepository.GetProductByName(name);
        }

        public async Task<bool> RemoveProductAsync(string id)
        {
            return await _productRepository.Delete(id);
        }

        public async Task<Product> UpdateProductAsync(string id, Product obj)
        {
            return await _productRepository.Update(id, obj);
        }
    }
}
