using BrainStormInActionDB.DataAccess.EntityConfigurations;
using BrainStormInActionDB.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BrainStormInActionDB.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Flow> Flow { get; set; } // Flow
        public DbSet<FlowsToVideo> FlowsToVideo { get; set; } // FlowsToVideo
        public DbSet<Group> Group { get; set; } // Group
        public DbSet<GroupsToFlow> GroupsToFlow { get; set; } // GroupsToFlow
        public DbSet<GroupsToVideo> GroupsToVideo { get; set; } // GroupsToVideo
        public DbSet<User> User { get; set; } // User
        public DbSet<UsersToFlow> UsersToFlow { get; set; } // UsersToFlow
        public DbSet<UsersToGroup> UsersToGroup { get; set; } // UsersToGroup
        public DbSet<UsersToVideo> UsersToVideo { get; set; } // UsersToVideo
        public DbSet<Video> Video { get; set; } // Video


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FlowsToVideoConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupsToFlowConfiguration());
            modelBuilder.ApplyConfiguration(new GroupsToVideoConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UsersToFlowConfiguration());
            modelBuilder.ApplyConfiguration(new UsersToGroupConfiguration());
            modelBuilder.ApplyConfiguration(new UsersToVideoConfiguration());
            modelBuilder.ApplyConfiguration(new VideoConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BrainStormInActionDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        
    }
}
