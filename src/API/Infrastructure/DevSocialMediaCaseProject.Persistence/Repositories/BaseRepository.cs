using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Constants;
using DevSocialMediaCaseProject.Common.Domain;
using DevSocialMediaCaseProject.Common.Exceptions;
using DevSocialMediaCaseProject.Persistence.Contexts;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Persistence.Repositories
{
    public class BaseRepository<T> : IRepository<T>
        where T : BaseEntity
    {
        protected readonly IMongoDBContext _mongoContext;
        protected IMongoCollection<T> _dbCollection;

        public BaseRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<T>(typeof(T).Name);
        }

        #region Async Ops.
        public async Task AddAsync(T entity)
        {
            await _dbCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            var objectId = new ObjectId(id);
            await _dbCollection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", objectId));
        }
        public async Task UpdateAsync(T entity)
        {
            CheckObjectWhileIsNullThrowException(entity);
            await _dbCollection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", entity.Id), entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await GetAllAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var objectId = new ObjectId(id);

            FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", objectId);

            return await Get(filter);
        }
        public async Task<T> Get(FilterDefinition<T> filter) => await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
        public async Task<IEnumerable<T>> GetAllAsync(FilterDefinition<T> filter = null)
        {
            var allEntities = await _dbCollection.FindAsync(filter == null ? Builders<T>.Filter.Empty : filter);
            return await allEntities.ToListAsync();
        }
        #endregion



        #region Checks
        private bool IsObjectNull(T entity) => entity != null ? true : false;
        private void CheckObjectWhileIsNullThrowException(T entity)
        {
            if (IsObjectNull(entity)) throw new DatabaseException(ExceptionConstants.OBJECT_IS_NULL);
        }

        #endregion
    }
}
