using MinhasFinancas.Infra.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using MinhasFinancas.Infra.Models;

namespace MinhasFinancas.Repository.Core
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task Add(TEntity obj);
        Task Update(TEntity obj);
        Task Delete(TEntity obj);
        Task DeleteById(object id);
        Task<int> SaveChanges();

        Task<IEnumerable<TEntity>> GetAll(
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = null,
           int? skip = null,
           int? take = null);

        Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null);

        Task<TEntity> GetById(object id);

        string GetDatabaseName();
    }
}