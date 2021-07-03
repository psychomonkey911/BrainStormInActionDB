using System.Threading.Tasks;
using BrainStormInActionDB.Domain.Interfaces;

namespace BrainStormInActionDB.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context
        , IVideoRepository videoRepository
        , IUsersToVideoRepository usersToVideoRepository
        , IUsersToGroupRepository usersToGroupRepository
        , IUsersToFlowRepository usersToFlowRepository
        , IUserRepository userRepository
        , IGroupsToVideoRepository groupsToVideoRepository
        , IGroupsToFlowRepository groupsToFlowRepository
        , IGroupRepository groupRepository
        , IFlowsToVideoRepository flowsToVideoRepository
        , IFlowRepository flowRepository
        )
        {
            _context = context;
            VideoRepository = videoRepository;
            UsersToVideoRepository = usersToVideoRepository;
            UsersToGroupRepository = usersToGroupRepository;
            UsersToFlowRepository = usersToFlowRepository;
            UserRepository = userRepository;
            GroupsToVideoRepository = groupsToVideoRepository;
            GroupsToFlowRepository = groupsToFlowRepository;
            GroupRepository = groupRepository;
            FlowsToVideoRepository = flowsToVideoRepository;
            FlowRepository = flowRepository;
        }

       public IVideoRepository VideoRepository { get; }
       public IUsersToVideoRepository UsersToVideoRepository { get; }
       public IUsersToGroupRepository UsersToGroupRepository { get; }
       public IUsersToFlowRepository UsersToFlowRepository { get; }
       public IUserRepository UserRepository { get; }
       public IGroupsToVideoRepository GroupsToVideoRepository { get; }
       public IGroupsToFlowRepository GroupsToFlowRepository { get; }
       public IGroupRepository GroupRepository { get; }
       public IFlowsToVideoRepository FlowsToVideoRepository { get; }
       public IFlowRepository FlowRepository { get; }

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
