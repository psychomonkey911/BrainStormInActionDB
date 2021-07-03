using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using BrainStormInActionDB.DataAccess;
using BrainStormInActionDB.Domain.Models;

namespace BrainStormInActionDB
{
    public static class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>()))
            {
                //check for data Flow in db
                if (context.Flow.AsNoTracking().Any())
                {
                    return;
                }
                context.Database.Migrate();
                AddSeedsToContext(context);
                context.SaveChanges();
            }
        }

        private static void AddSeedsToContext(ApplicationContext context)
        {
            AddUsers(context);
            AddFlow(context);
            AddVideos(context);
            AddGroups(context);
            AddUsersToVideo(context);
            AddUsersToGroups(context);
            AddUsersToFlow(context);
            AddGroupsToVideo(context);
            AddGroupsToFlow(context);
            AddFlowsToVideo(context);
        }

        private static void AddUsers(ApplicationContext context)
        {
            context.User.AddRange(
                new User
                {
                    Id = 1
                }, new User
                {
                    Id = 2
                }, new User
                {
                    Id = 3
                }, new User
                {
                    Id = 4
                }, new User
                {
                    Id = 5
                }, new User
                {
                    Id = 6
                }, new User
                {
                    Id = 7
                }, new User
                {
                    Id = 8
                }, new User
                {
                    Id = 9
                }, new User
                {
                    Id = 10
                });
        }

        private static void AddFlow(ApplicationContext context)
        {
            context.Flow.AddRange(
                 new Flow
                 {
                     Id = 1
                 },
                 new Flow
                 {
                     Id = 2
                 },
                 new Flow
                 {
                     Id = 3
                 },
                 new Flow
                 {
                     Id = 4
                 },
                 new Flow
                 {
                     Id = 5
                 },
                 new Flow
                 {
                     Id = 6
                 },
                 new Flow
                 {
                     Id = 7
                 },
                 new Flow
                 {
                     Id = 8
                 },
                 new Flow
                 {
                     Id = 9
                 },
                 new Flow
                 {
                     Id = 10
                 },
                 new Flow
                 {
                     Id = 11
                 },
                 new Flow
                 {
                     Id = 12
                 }
             );
        }

        private static void AddVideos(ApplicationContext context)
        {
            context.Video.AddRange(
                new Video
                {
                    Id = 1,
                    Name = "Video 1"
                },
                new Video
                {
                    Id = 2,
                    Name = "Video 2"
                }, new Video
                {
                    Id = 3,
                    Name = "Video 3"
                }, new Video
                {
                    Id = 4,
                    Name = "Video 4"
                }, new Video
                {
                    Id = 5,
                    Name = "Video 5"
                }, new Video
                {
                    Id = 6,
                    Name = "Video 6"
                }, new Video
                {
                    Id = 7,
                    Name = "Video 7"
                }, new Video
                {
                    Id = 8,
                    Name = "Video 8"
                }, new Video
                {
                    Id = 9,
                    Name = "Video 9"
                }, new Video
                {
                    Id = 10,
                    Name = "Video 10"
                }, new Video
                {
                    Id = 11,
                    Name = "Video 11"
                }
            );
        }

        private static void AddGroups(ApplicationContext context)
        {
            context.Group.AddRange(
                new Group
                {
                    Id = 1
                },
                new Group
                {
                    Id = 2
                },
                new Group
                {
                    Id = 3
                },
                new Group
                {
                    Id = 4
                },
                new Group
                {
                    Id = 5
                },
                new Group
                {
                    Id = 6
                },
                new Group
                {
                    Id = 7
                },
                new Group
                {
                    Id = 8
                },
                new Group
                {
                    Id = 9
                }
            );
        }

        private static void AddUsersToVideo(ApplicationContext context)
        {
            context.UsersToVideo.AddRange(
                new UsersToVideo
                {
                    UserId = 1,
                    VideoId = 1,
                    Priority = "low"
                },
                new UsersToVideo
                {
                    UserId = 2,
                    VideoId = 2,
                    Priority = "low"
                },
                new UsersToVideo
                {
                    UserId = 3,
                    VideoId = 3,
                    Priority = "low"
                },
                new UsersToVideo
                {
                    UserId = 4,
                    VideoId = 4,
                    Priority = "low"
                },
                new UsersToVideo
                {
                    UserId = 5,
                    VideoId = 5,
                    Priority = "medium"
                },
                new UsersToVideo
                {
                    UserId = 5,
                    VideoId = 6,
                    Priority = "high"
                },
                new UsersToVideo
                {
                    UserId = 5,
                    VideoId = 7,
                    Priority = "low"
                },
                new UsersToVideo
                {
                    UserId = 7,
                    VideoId = 5,
                    Priority = "medium"
                },
                new UsersToVideo
                {
                    UserId = 7,
                    VideoId = 5,
                    Priority = "low"
                },
                new UsersToVideo
                {
                    UserId = 7,
                    VideoId = 5,
                    Priority = "high"
                }

            );
        }

        private static void AddUsersToGroups(ApplicationContext context)
        {
            context.UsersToGroup.AddRange(
                new UsersToGroup
                {
                    UserId = 1,
                    GroupId = 1
                },
                new UsersToGroup
                {
                    UserId = 2,
                    GroupId = 2
                },
                new UsersToGroup
                {
                    UserId = 3,
                    GroupId = 3
                },
                new UsersToGroup
                {
                    UserId = 4,
                    GroupId = 3
                },
                new UsersToGroup
                {
                    UserId = 4,
                    GroupId = 4
                },
                new UsersToGroup
                {
                    UserId = 7,
                    GroupId = 7
                },
                new UsersToGroup
                {
                    UserId = 7,
                    GroupId = 8
                }
            );
        }

        private static void AddUsersToFlow(ApplicationContext context)
        {
            context.UsersToFlow.AddRange(
                new UsersToFlow
                {
                    UserId = 1,
                    FlowId = 1,
                    Priority = "critical"
                },
                new UsersToFlow
                {
                    UserId = 4,
                    FlowId = 2,
                    Priority = "critical"
                },
                new UsersToFlow
                {
                    UserId = 5,
                    FlowId = 4,
                    Priority = "medium"
                },
                new UsersToFlow
                {
                    UserId = 6,
                    FlowId = 5,
                    Priority = "low"
                },
                new UsersToFlow
                {
                    UserId = 6,
                    FlowId = 6,
                    Priority = "high"
                },
                new UsersToFlow
                {
                    UserId = 7,
                    FlowId = 7,
                    Priority = "low"
                },
                new UsersToFlow
                {
                    UserId = 7,
                    FlowId = 8,
                    Priority = "low"
                },
                new UsersToFlow
                {
                    UserId = 7,
                    FlowId = 9,
                    Priority = "medium"
                },
                new UsersToFlow
                {
                    UserId = 9,
                    FlowId = 12,
                    Priority = "low"
                },
                new UsersToFlow
                {
                    UserId = 10,
                    FlowId = 11,
                    Priority = "high"
                }
            );
        }

        private static void AddGroupsToVideo(ApplicationContext context)
        {
            context.GroupsToVideo.AddRange(
                new GroupsToVideo
                {
                    GroupId = 1,
                    VideoId = 2,
                    Priority = "high"
                },
                new GroupsToVideo
                {
                    GroupId = 2,
                    VideoId = 3,
                    Priority = "high"
                },
                new GroupsToVideo
                {
                    GroupId = 3,
                    VideoId = 4,
                    Priority = "high"
                },
                new GroupsToVideo
                {
                    GroupId = 5,
                    VideoId = 8,
                    Priority = "medium"
                },
                new GroupsToVideo
                {
                    GroupId = 6,
                    VideoId = 9,
                    Priority = "high"
                },
                new GroupsToVideo
                {
                    GroupId = 7,
                    VideoId = 7,
                    Priority = "high"
                },
                new GroupsToVideo
                {
                    GroupId = 7,
                    VideoId = 7,
                    Priority = "low"
                },
                new GroupsToVideo
                {
                    GroupId = 7,
                    VideoId = 7,
                    Priority = "medium"
                }
            );
        }

        private static void AddGroupsToFlow(ApplicationContext context)
        {
            context.GroupsToFlow.AddRange(
                new GroupsToFlow
                {
                    GroupId = 4,
                    FlowId = 3,
                    Priority = "medium"
                },
                new GroupsToFlow
                {
                    GroupId = 5,
                    FlowId = 4,
                    Priority = "high"
                },
                new GroupsToFlow
                {
                    GroupId = 7,
                    FlowId = 10,
                    Priority = "high"
                },
                new GroupsToFlow
                {
                    GroupId = 8,
                    FlowId = 11,
                    Priority = "medium"
                },
                new GroupsToFlow
                {
                    GroupId = 8,
                    FlowId = 12,
                    Priority = "high"
                }
            );
        }

        private static void AddFlowsToVideo(ApplicationContext context)
        {
            context.FlowsToVideo.AddRange(
                new FlowsToVideo
                {
                    FlowId = 1,
                    VideoId = 3
                },
                new FlowsToVideo
                {
                    FlowId = 3,
                    VideoId = 4
                },
                new FlowsToVideo
                {
                    FlowId = 4,
                    VideoId = 5
                },
                new FlowsToVideo
                {
                    FlowId = 4,
                    VideoId = 7
                },
                new FlowsToVideo
                {
                    FlowId = 5,
                    VideoId = 9
                },
                new FlowsToVideo
                {
                    FlowId = 4,
                    VideoId = 10
                },
                new FlowsToVideo
                {
                    FlowId = 5,
                    VideoId = 11
                }
            );
        }
    }
}