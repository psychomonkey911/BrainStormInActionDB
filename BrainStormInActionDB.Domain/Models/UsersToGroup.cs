using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    // UsersToGroup
    public class UsersToGroup
    {
        public int UserId { get; set; } // UserId (Primary key)
        public int GroupId { get; set; } // GroupId (Primary key)

        // Foreign keys

        /// <summary>
        /// Parent Group pointed by [UsersToGroup].([GroupId]) (FK_UsersToGroup_Groups)
        /// </summary>
        public virtual Group Group { get; set; } // FK_UsersToGroup_Groups

        /// <summary>
        /// Parent User pointed by [UsersToGroup].([UserId]) (FK_UsersToGroup_Users)
        /// </summary>
        public virtual User User { get; set; } // FK_UsersToGroup_Users
    }
}
