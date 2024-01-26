using MinhasFinancas.Infra.Data;
using MinhasFinancas.Infra.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MinhasFinancas.Repository.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {

        internal readonly AppDbContext _db;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();

            _db.Configuration.ProxyCreationEnabled = false;
            _db.Configuration.LazyLoadingEnabled = false;
        }

        public virtual async Task Add(TEntity obj)
        {
            _dbSet.Add(obj);
        }
        public virtual async Task Update(TEntity obj)
        {
            _dbSet.Attach(obj);
            var oEntry = _db.Entry(obj);
            oEntry.State = EntityState.Modified;
        }


        public virtual async Task Delete(TEntity obj)
        {
            _dbSet.Attach(obj);
            _dbSet.Remove(obj);
        }

        public virtual async Task DeleteById(object id)
        {
            var obj = _dbSet.Find(id);

            if (obj != null)
                _dbSet.Remove(obj);
            else
                throw new KeyNotFoundException();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(
         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
         string includeProperties = null,
        int? skip = null,
         int? take = null)
        {
            return await GetQueryable(null, orderBy, includeProperties, skip, take);
        }

        public virtual async Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
        int? skip = null,
            int? take = null)
        {
            return await GetQueryable(filter, orderBy, includeProperties, skip, take);
        }

        public virtual async Task<TEntity> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        protected virtual async Task<IQueryable<TEntity>> GetQueryable(
                    Expression<Func<TEntity, bool>> filter = null,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                    string includeProperties = null,
                    int? skip = null,
                    int? take = null)
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return await Task.FromResult(query.AsNoTracking());
        }

        public async Task<int> SaveChanges()
        {
            var saveChanges = 0;
            try
            {
                saveChanges = await _db.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var validationErros in e.EntityValidationErrors)
                {
                    foreach (var validationErro in validationErros.ValidationErrors)
                    {
                        System.ArgumentException ex = new System.ArgumentException(validationErro.ErrorMessage, validationErro.PropertyName, e);
                        throw ex;
                    }
                }
            }

            return saveChanges;
        }

        public string GetDatabaseName()
        {
            return _db.Database.Connection.Database;
        }
    }
}