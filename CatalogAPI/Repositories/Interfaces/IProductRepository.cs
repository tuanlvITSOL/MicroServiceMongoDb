
using CatalogAPI.Entities;
using CatalogAPI.Repositories.interfaceBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogAPI.Repositories.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);
    }
}
