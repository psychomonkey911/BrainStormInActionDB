using System.Net.Http;
using BrainStormInActionDB.DataAccess.Repositories;
using BrainStormInActionDB.DataAccess.UnitOfWork;
using BrainStormInActionDB.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BrainStormInActionDB.Extensions
{
    public static class DependencyInjectionDataLayer
    {
        public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFlowRepository, FlowRepository>();
            services.AddScoped<IFlowsToVideoRepository, FlowsToVideoRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupsToFlowRepository, GroupsToFlowRepository>();
            services.AddScoped<IGroupsToVideoRepository, GroupsToVideoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUsersToFlowRepository, UsersToFlowRepository>();
            services.AddScoped<IUsersToGroupRepository, UsersToGroupRepository>();
            services.AddScoped<IUsersToVideoRepository, UsersToVideoRepository>();
            services.AddScoped<IVideoRepository, VideoRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
