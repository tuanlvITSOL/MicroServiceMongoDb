using CatalogAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> AddCategoryAsync(Category obj);
        Task<Category> UpdateCategoryAsync(string id, Category obj);
        Task<bool> RemoveCategoryAsync(string id);
        Task<Category> GetByIdAsync(string id);
        Task<IEnumerable<Category>> GetAll();
    }
}
