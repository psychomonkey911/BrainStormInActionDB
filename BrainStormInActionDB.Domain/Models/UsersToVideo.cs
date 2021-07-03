using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    // UsersToVideo
    public class UsersToVideo
    {
        public int UserId { get; set; } // UserId (Primary key)
        public int VideoId { get; set; } // VideoId (Primary key)
        public string Priority { get; set; } // Priority (Primary key) (length: 50)

        // Foreign keys

        /// <summary>
        /// Parent User pointed by [UsersToVideo].([UserId]) (FK_UsersToVideo_Users)
        /// </summary>
        public virtual User User { get; set; } // FK_UsersToVideo_Users

        /// <summary>
        /// Parent Video pointed by [UsersToVideo].([VideoId]) (FK_UsersToVideo_Video)
        /// </summary>
        public virtual Video Video { get; set; } // FK_UsersToVideo_Video
    }
}
