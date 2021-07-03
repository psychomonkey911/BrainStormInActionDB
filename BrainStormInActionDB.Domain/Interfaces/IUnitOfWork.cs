using System;
using System.Threading.Tasks;

namespace BrainStormInActionDB.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        Task<int> CompleteAsync();
    }
}