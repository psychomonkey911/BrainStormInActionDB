using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    // Users
    public class User
    {
        public int Id { get; set; } // Id (Primary key)

        // Reverse navigation

        /// <summary>
        /// Child UsersToFlows where [UsersToFlow].[UserId] point to this entity (FK_UsersToFlow_Users)
        /// </summary>
        [JsonIgnore] 
        public virtual ICollection<UsersToFlow> UsersToFlows { get; set; } // UsersToFlow.FK_UsersToFlow_Users

        /// <summary>
        /// Child UsersToGroups where [UsersToGroup].[UserId] point to this entity (FK_UsersToGroup_Users)
        /// </summary>
        [JsonIgnore] 
        public virtual ICollection<UsersToGroup> UsersToGroups { get; set; } // UsersToGroup.FK_UsersToGroup_Users

        /// <summary>
        /// Child UsersToVideos where [UsersToVideo].[UserId] point to this entity (FK_UsersToVideo_Users)
        /// </summary>
        [JsonIgnore] 
        public virtual ICollection<UsersToVideo> UsersToVideos { get; set; } // UsersToVideo.FK_UsersToVideo_Users

        //public User()
        //{
        //    UsersToFlows = new List<UsersToFlow>();
        //    UsersToGroups = new List<UsersToGroup>();
        //    UsersToVideos = new List<UsersToVideo>();
        //}
    }
}
