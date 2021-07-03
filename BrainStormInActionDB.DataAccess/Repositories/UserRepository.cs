using BrainStormInActionDB.Domain.Interfaces;
using BrainStormInActionDB.Domain.Models;
using NLog;

namespace BrainStormInActionDB.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        #region Fields

        Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Ctor

        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        #endregion

        #region Method



        #endregion
    }
}
