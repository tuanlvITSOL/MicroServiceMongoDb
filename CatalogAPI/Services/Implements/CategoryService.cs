using CatalogAPI.Entities;
using CatalogAPI.Repositories.Interfaces;
using CatalogAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogAPI.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private ICategotyReponsitory _categotyReponsitory;
        public CategoryService(ICategotyReponsitory categotyReponsitory)
        {
            _categotyReponsitory = categotyReponsitory;
        }
        public async Task<Category> AddCategoryAsync(Category obj)
        {
             return await _categotyReponsitory.Create(obj);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categotyReponsitory.GetAllValues();
        }

        public async Task<Category> GetByIdAsync(string id)
        {
            return await _categotyReponsitory.GetValueById(id);
        }

        public async Task<bool> RemoveCategoryAsync(string id)
        {
            return await _categotyReponsitory.Delete(id);
        }

        public async Task<Category> UpdateCategoryAsync(string id, Category obj)
        {
            return await _categotyReponsitory.Update(id, obj);
        }
    }
}
