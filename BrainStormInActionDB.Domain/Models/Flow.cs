using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    // Flow
    public class Flow
    {
        public int Id { get; set; } // Id (Primary key)

        // Reverse navigation

        /// <summary>
        /// Child FlowsToVideos where [FlowsToVideo].[FlowId] point to this entity (FK_FlowsToVideo_Flow)
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<FlowsToVideo> FlowsToVideos { get; set; } // FlowsToVideo.FK_FlowsToVideo_Flow

        /// <summary>
        /// Child GroupsToFlows where [GroupsToFlow].[FlowId] point to this entity (FK_GroupsToFlow_Flow)
        /// </summary>
        [JsonIgnore] 
        public virtual ICollection<GroupsToFlow> GroupsToFlows { get; set; } // GroupsToFlow.FK_GroupsToFlow_Flow

        /// <summary>
        /// Child UsersToFlows where [UsersToFlow].[FlowId] point to this entity (FK_UsersToFlow_Flow)
        /// </summary>
        [JsonIgnore] 
        public virtual ICollection<UsersToFlow> UsersToFlows { get; set; } // UsersToFlow.FK_UsersToFlow_Flow

        //public Flow()
        //{
        //    FlowsToVideos = new List<FlowsToVideo>();
        //    GroupsToFlows = new List<GroupsToFlow>();
        //    UsersToFlows = new List<UsersToFlow>();
        //}
    }
}
