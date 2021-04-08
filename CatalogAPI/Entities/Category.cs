using CatalogAPI.Entities.Base;

namespace CatalogAPI.Entities
{
    
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
