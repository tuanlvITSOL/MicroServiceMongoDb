using CatalogAPI.Entities.Base;
using MongoDB.Bson.Serialization.Attributes;

namespace CatalogAPI.Entities
{
    [BsonDiscriminator("Products")]
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public string ImageFile { get; set; }

        public decimal Price { get; set; }
    }
}
