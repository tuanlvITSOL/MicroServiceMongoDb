using CatalogAPI.Data.Interfaces;
using CatalogAPI.Entities;
using CatalogAPI.Repositories.BaseResponsitory.ImplementBase;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogAPI.Repositories.Interfaces
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        protected readonly IMongoDatabase Database;
        private readonly IMongoCollection<Product> DbSet;
        public ProductRepository(IMongoContext context) : base(context)
        {
            Database = context.Database;
            DbSet = Database.GetCollection<Product>(typeof(Product).Name);
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(x => x.Category, categoryName);
            return await DbSet.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(x => x.Name, name);
            return await DbSet.Find(filter).ToListAsync();
        }
    }
}
