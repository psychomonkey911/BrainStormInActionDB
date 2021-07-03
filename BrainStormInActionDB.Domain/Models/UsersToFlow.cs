using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    // UsersToFlow
    public class UsersToFlow
    {
        public int UserId { get; set; } // UserId (Primary key)
        public int FlowId { get; set; } // FlowId (Primary key)
        public string Priority { get; set; } // Priority (Primary key) (length: 50)

        // Foreign keys

        /// <summary>
        /// Parent Flow pointed by [UsersToFlow].([FlowId]) (FK_UsersToFlow_Flow)
        /// </summary>
        public virtual Flow Flow { get; set; } // FK_UsersToFlow_Flow

        /// <summary>
        /// Parent User pointed by [UsersToFlow].([UserId]) (FK_UsersToFlow_Users)
        /// </summary>
        public virtual User User { get; set; } // FK_UsersToFlow_Users
    }
}
