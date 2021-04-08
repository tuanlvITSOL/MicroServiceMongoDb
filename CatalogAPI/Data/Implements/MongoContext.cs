using CatalogAPI.Data.Interfaces;
using CatalogAPI.Settings;
using MongoDB.Driver;

namespace CatalogAPI.Data
{
    public class MongoContext : IMongoContext
    {
        public MongoContext(ICatalogDatabaseSettings connectionSetting)
        {
            var client = new MongoClient(connectionSetting.ConnectionString);
            Database = client.GetDatabase(connectionSetting.DatabaseName);
        }

        public IMongoDatabase Database { get; }

    }
}
