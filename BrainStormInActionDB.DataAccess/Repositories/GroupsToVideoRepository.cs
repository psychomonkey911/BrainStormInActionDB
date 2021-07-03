using BrainStormInActionDB.Domain.Interfaces;
using BrainStormInActionDB.Domain.Models;
using NLog;

namespace BrainStormInActionDB.DataAccess.Repositories
{
    public class GroupsToVideoRepository : GenericRepository<GroupsToVideo>, IGroupsToVideoRepository
    {
        #region Fields

        Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Ctor

        public GroupsToVideoRepository(ApplicationContext context) : base(context)
        {
        }

        #endregion

        #region Method



        #endregion
    }
}
