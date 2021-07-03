using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    // Groups
    public class Group
    {
        public int Id { get; set; } // Id (Primary key)

        // Reverse navigation

        /// <summary>
        /// Child GroupsToFlows where [GroupsToFlow].[GroupId] point to this entity (FK_GroupsToFlow_Groups)
        /// </summary>
        [JsonIgnore] 
        public virtual ICollection<GroupsToFlow> GroupsToFlows { get; set; } // GroupsToFlow.FK_GroupsToFlow_Groups

        /// <summary>
        /// Child GroupsToVideos where [GroupsToVideo].[GroupId] point to this entity (FK_GroupsToVideo_Groups)
        /// </summary>
        [JsonIgnore] 
        public virtual ICollection<GroupsToVideo> GroupsToVideos { get; set; } // GroupsToVideo.FK_GroupsToVideo_Groups

        /// <summary>
        /// Child UsersToGroups where [UsersToGroup].[GroupId] point to this entity (FK_UsersToGroup_Groups)
        /// </summary>
        [JsonIgnore] 
        public virtual ICollection<UsersToGroup> UsersToGroups { get; set; } // UsersToGroup.FK_UsersToGroup_Groups

        //public Group()
        //{
        //    GroupsToFlows = new List<GroupsToFlow>();
        //    GroupsToVideos = new List<GroupsToVideo>();
        //    UsersToGroups = new List<UsersToGroup>();
        //}
    }
}
