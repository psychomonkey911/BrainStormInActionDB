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

        public virtual async Task<List<T>> FindAllWithIncludeAsync(string sortOrder = "desc", Expression<Func<T, bool>> filter = null, Func<T, object> predicate=null, params Expression<Func<T, object>>[] includeProperties)
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

            //if (predicate != null && sortOrder.ToLowerInvariant().Contains("asc"))
            //{
            //    baseQuery.OrderBy(predicate);
            //}
            //else
            //{
            //    baseQuery.OrderByDescending(predicate);
            //}
               
            return await baseQuery.ToListAsync();
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
