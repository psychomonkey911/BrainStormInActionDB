using BrainStormInActionDB.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BrainStormInActionDB.DataAccess.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;
        protected DbSet<T> _dbSet;
        Logger _logger = LogManager.GetCurrentClassLogger();

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            var exist = await _context.Set<T>().FindAsync(id);
            _context.Entry(exist).State = EntityState.Detached;
            return exist;
        }

        public virtual T Add(T t)
        {
            _context.Set<T>().Add(t);
            return t;
        }

        public virtual async Task<T> AddAsync(T t)
        {
            try
            {
                _context.Set<T>().Add(t);
            }
            catch (Exception e)
            {
                _logger.Error($"GenericRepository:AddAsync >>> Message: {e.Message}, StackTrace: {e.StackTrace}");
                throw;
            }

            return t;
        }

        public virtual T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().SingleOrDefault(match);
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match).ToList();
        }

        public virtual async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).ToListAsync();
        }

        public virtual async Task<List<T>> FindAllWithIncludeAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> baseQuery = _context.Set<T>().AsNoTracking();
            if (includeProperties?.Length > 0)
            {
                foreach (Expression<Func<T, object>> includeProperty in includeProperties)
                {
                    baseQuery = baseQuery.Include<T, object>(includeProperty);
                }
            }

            if (filter != null)
            {
                baseQuery = baseQuery.Where(filter);
            }


            return await baseQuery.ToListAsync();
        }

        public virtual async Task<T> FirstOfDefaultWithIncludeAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> baseQuery = _context.Set<T>().AsNoTracking();
            if (includeProperties?.Length > 0)
            {
                foreach (Expression<Func<T, object>> includeProperty in includeProperties)
                {
                    baseQuery = baseQuery.Include<T, object>(includeProperty);
                }
            }

            if (filter != null)
            {
                baseQuery = baseQuery.Where(filter);
            }


            return await baseQuery.FirstOrDefaultAsync();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual async Task<T> DeleteAsyn(T entity)
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }

        public virtual T Update(T t, int key)
        {
            if (t == null)
                return null;
            T exist = _context.Set<T>().Find(key);
            if (exist == null)
                return null;
            try
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
            }
            catch (DbUpdateConcurrencyException dbUc)
            {
                _logger.Error($"GenericRepository:UpdateAsync >>> Message: {dbUc.Message}, StackTrace: {dbUc.StackTrace}");
            }
            catch (DbUpdateException dbU)
            {
                _logger.Error($"GenericRepository:UpdateAsync >>> Message: {dbU.Message}, StackTrace: {dbU.StackTrace}");
            }

            return t;
        }

        public virtual async Task<T> UpdateAsync(T t, int key)
        {
            var entity = await GetAsync(key);
            if (entity == null)
                return null;
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.Set<T>().Update(t);
                return t;
            }
            catch (DbUpdateConcurrencyException dbUc)
            {
                _logger.Error($"GenericRepository:UpdateAsync >>> Message: {dbUc.Message}, StackTrace: {dbUc.StackTrace}");
            }
            catch (DbUpdateException dbU)
            {
                _logger.Error($"GenericRepository:UpdateAsync >>> Message: {dbU.Message}, StackTrace: {dbU.StackTrace}");
            }

            return null;
        }


        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public virtual async Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<List<T>> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = GetAll();
            if (includeProperties != null)
                includeProperties.ToList().ForEach(include =>
                {
                    if (include != null)
                        queryable = queryable.Include(include);
                });

            return queryable.ToListAsync();
        }

        public async Task<IQueryable<T>> ExecuteQuerySingle(string query)
        {
            var r = _dbSet.FromSqlRaw(query);
            return r;
        }

        public async Task<IEnumerable<T>> ExecuteQuery(string query, params object[] parameters)
        {
            var r = _dbSet.FromSqlRaw(query, parameters).AsEnumerable();
            return r;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
