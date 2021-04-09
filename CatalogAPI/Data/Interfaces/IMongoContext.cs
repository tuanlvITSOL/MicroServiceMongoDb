

using MongoDB.Driver;

namespace CatalogAPI.Data.Interfaces
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }
    }
}
