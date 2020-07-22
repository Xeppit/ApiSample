using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiSample.Api.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ApiSample.Api.Repositories
{
    public abstract class RepositoryBase<T> where T : IDbModel
    {
        private readonly IMongoCollection<T> _collection;

        protected RepositoryBase(IMongoCollection<T> collection)
        {
            _collection = collection;
        }

        public IMongoQueryable<T> GetFiltered(Expression<Func<T, bool>> predicate)
        {
            return _collection.AsQueryable()
                .Where(predicate);
        }

        public virtual async Task InsertAsync(T input)
        {
            await _collection.InsertOneAsync(input);
        }

        public virtual async Task InsertManyAsync(List<T> input)
        {
            await _collection.InsertManyAsync(input);
        }

        public virtual async Task UpdateAsync(string id, T input)
        {
            await _collection.ReplaceOneAsync(x => x.Id == id, input);
        }

        public virtual async Task UpdateManyAsync(Expression<Func<T, bool>> predicate, UpdateDefinition<T> definition, bool isUpsert)
        {
            await _collection.UpdateManyAsync(predicate, definition, new UpdateOptions { IsUpsert = isUpsert });
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            var result = await GetFiltered(x => x.Id != null).ToListAsync();
            return result;
        }

        public virtual async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await GetFiltered(predicate).FirstOrDefaultAsync();
            return result;
        }

        public virtual async Task<List<T>> FindManyAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await GetFiltered(predicate).ToListAsync();
            return result;
        }

        public virtual async Task<DeleteResult> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.DeleteOneAsync(predicate);
        }

        public virtual async Task<DeleteResult> DeleteManyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.DeleteManyAsync(predicate);
        }
    }
}
