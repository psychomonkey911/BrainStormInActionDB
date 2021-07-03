using BrainStormInActionDB.Domain.Interfaces;
using BrainStormInActionDB.Domain.Models;
using NLog;

namespace BrainStormInActionDB.DataAccess.Repositories
{
    public class GroupsToFlowRepository : GenericRepository<GroupsToFlow>, IGroupsToFlowRepository
    {
        #region Fields

        Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Ctor

        public GroupsToFlowRepository(ApplicationContext context) : base(context)
        {
        }

        #endregion

        #region Method



        #endregion
    }
}
