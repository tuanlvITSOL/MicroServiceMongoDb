using MongoDB.Driver;

namespace CatalogAPI.Data.Interfaces
{
    public interface IRepositoryContextBase<T>
    {
        IMongoCollection<T> entities { get; }
    }
}
