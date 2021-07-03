using BrainStormInActionDB.Domain.Interfaces;
using BrainStormInActionDB.Domain.Models;
using NLog;

namespace BrainStormInActionDB.DataAccess.Repositories
{
    public class UsersToFlowRepository : GenericRepository<UsersToFlow>, IUsersToFlowRepository
    {
        #region Fields

        Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Ctor

        public UsersToFlowRepository(ApplicationContext context) : base(context)
        {
        }

        #endregion

        #region Method



        #endregion
    }
}
