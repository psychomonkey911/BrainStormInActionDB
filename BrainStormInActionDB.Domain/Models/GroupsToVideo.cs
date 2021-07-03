using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    // GroupsToVideo
    public class GroupsToVideo
    {
        public int GroupId { get; set; } // GroupId (Primary key)
        public int VideoId { get; set; } // VideoId (Primary key)
        public string Priority { get; set; } // Priority (Primary key) (length: 50)

        // Foreign keys

        /// <summary>
        /// Parent Group pointed by [GroupsToVideo].([GroupId]) (FK_GroupsToVideo_Groups)
        /// </summary>
        [JsonIgnore] 
        public virtual Group Group { get; set; } // FK_GroupsToVideo_Groups

        /// <summary>
        /// Parent Video pointed by [GroupsToVideo].([VideoId]) (FK_GroupsToVideo_Video)
        /// </summary>
        [JsonIgnore] 
        public virtual Video Video { get; set; } // FK_GroupsToVideo_Video
    }
}
