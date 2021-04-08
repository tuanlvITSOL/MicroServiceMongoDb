using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogAPI.Repositories.interfaceBase
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllValues();
        Task<TEntity> GetValueById(string id);
        Task<TEntity> Create(TEntity obj);
        Task<TEntity> Update(string id, TEntity entity);
        Task<bool> Delete(string id);
    }
}
