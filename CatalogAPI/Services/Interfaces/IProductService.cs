
using CatalogAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogAPI.Services.Interfaces
{
   public interface IProductService
    {
        Task<Product> AddProductAsync(Product obj);
        Task<Product> UpdateProductAsync(string id, Product obj);
        Task<bool> RemoveProductAsync(string id);
        Task<Product> GetByIdAsync(string id);
        Task<IEnumerable<Product>> GetAll();
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);
    }
}
