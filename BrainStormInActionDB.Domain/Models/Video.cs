using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    // Video
    public class Video
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 150)

        // Reverse navigation

        /// <summary>
        /// Child FlowsToVideos where [FlowsToVideo].[VideoId] point to this entity (FK_FlowsToVideo_Video)
        /// </summary>
        public virtual ICollection<FlowsToVideo> FlowsToVideos { get; set; } // FlowsToVideo.FK_FlowsToVideo_Video

        /// <summary>
        /// Child GroupsToVideos where [GroupsToVideo].[VideoId] point to this entity (FK_GroupsToVideo_Video)
        /// </summary>
        public virtual ICollection<GroupsToVideo> GroupsToVideos { get; set; } // GroupsToVideo.FK_GroupsToVideo_Video

        /// <summary>
        /// Child UsersToVideos where [UsersToVideo].[VideoId] point to this entity (FK_UsersToVideo_Video)
        /// </summary>
        public virtual ICollection<UsersToVideo> UsersToVideos { get; set; } // UsersToVideo.FK_UsersToVideo_Video

        public Video()
        {
            FlowsToVideos = new List<FlowsToVideo>();
            GroupsToVideos = new List<GroupsToVideo>();
            UsersToVideos = new List<UsersToVideo>();
        }
    }
}
