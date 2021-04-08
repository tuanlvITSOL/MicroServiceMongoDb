using CatalogAPI.Data;
using CatalogAPI.Data.Interfaces;
using CatalogAPI.Repositories.interfaceBase;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogAPI.Repositories.BaseResponsitory.ImplementBase
{
    public  class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly IMongoDatabase Database;
        private readonly IMongoCollection<TEntity> DbSet;
        public RepositoryBase(IMongoContext context)
        {
            Database = context.Database;
            DbSet = Database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public virtual async Task<TEntity> Create(TEntity obj)
        {
            await DbSet.InsertOneAsync(obj);
            return obj;
        }

        public async virtual Task<bool> Delete(string id)
        {
            var result = await DbSet.DeleteOneAsync(FilterId(id));
            return result.IsAcknowledged;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllValues()
        {
            var result = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return await result.ToListAsync();
        }

        public async Task<TEntity> GetValueById(string id)
        {
            return await DbSet.Find(FilterId(id)).SingleOrDefaultAsync();
        }

        public async Task<TEntity> Update(string id, TEntity entity)
        {
            await DbSet.ReplaceOneAsync(filter: FilterId(id), replacement: entity);
            return entity;
        }

        private static FilterDefinition<TEntity> FilterId(string key)
        {
            return Builders<TEntity>.Filter.Eq("Id", key);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
