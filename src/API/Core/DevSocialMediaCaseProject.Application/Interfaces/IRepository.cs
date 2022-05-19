using DevSocialMediaCaseProject.Common.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Application.Interfaces
{
    public interface IRepository<T>
        where T: BaseEntity
    {
        #region Async Ops.
        Task AddAsync(T entity);
        Task<T> Get(FilterDefinition<T> filter);
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync(FilterDefinition<T> filter = null);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string id);
        #endregion



    }
}
