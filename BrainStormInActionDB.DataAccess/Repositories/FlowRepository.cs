using BrainStormInActionDB.Domain.Interfaces;
using BrainStormInActionDB.Domain.Models;
using NLog;

namespace BrainStormInActionDB.DataAccess.Repositories
{
    public class FlowRepository : GenericRepository<Flow>, IFlowRepository
    {
        #region Fields

        Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Ctor

        public FlowRepository(ApplicationContext context) : base(context)
        {
        }

        #endregion

        #region Method



        #endregion
    }
}
