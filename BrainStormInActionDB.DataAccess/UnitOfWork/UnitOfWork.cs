using System.Threading.Tasks;
using BrainStormInActionDB.Domain.Interfaces;

namespace BrainStormInActionDB.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }
        //public IScheduleQuery ScheduleQuery { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
