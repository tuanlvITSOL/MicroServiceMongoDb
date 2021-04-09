using CatalogAPI.Data.Interfaces;
using CatalogAPI.Entities;
using CatalogAPI.Repositories.BaseResponsitory.ImplementBase;
using CatalogAPI.Repositories.Interfaces;

namespace CatalogAPI.Repositories.Implements
{
    public class CategoryReponsitory : RepositoryBase<Category>, ICategotyReponsitory
    {
        public CategoryReponsitory(IMongoContext context) : base(context)
        {
        }
    }
}
