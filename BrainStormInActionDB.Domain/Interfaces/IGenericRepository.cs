using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BrainStormInActionDB.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> FindAllWithIncludeAsync(string sortOrder = "desc", Expression<Func<T, bool>> filter = null, Func<T, object> predicate = null, params Expression<Func<T, object>>[] includeProperties);
    }
}
