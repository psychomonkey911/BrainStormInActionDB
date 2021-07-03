using System;
using System.Threading.Tasks;

namespace BrainStormInActionDB.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }
        IUsersToVideoRepository UsersToVideoRepository { get; }
        IUsersToGroupRepository UsersToGroupRepository { get; }
        IUsersToFlowRepository UsersToFlowRepository { get; }
        IUserRepository UserRepository { get; }
        IGroupsToVideoRepository GroupsToVideoRepository { get; }
        IGroupsToFlowRepository GroupsToFlowRepository { get; }
        IGroupRepository GroupRepository { get; }
        IFlowsToVideoRepository FlowsToVideoRepository { get; }
        IFlowRepository FlowRepository { get; }


        int Complete();
        Task<int> CompleteAsync();
    }
}