using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    // GroupsToFlow
    public class GroupsToFlow
    {
        public int GroupId { get; set; } // GroupId (Primary key)
        public int FlowId { get; set; } // FlowId (Primary key)
        public string Priority { get; set; } // Priority (Primary key) (length: 50)

        // Foreign keys

        /// <summary>
        /// Parent Flow pointed by [GroupsToFlow].([FlowId]) (FK_GroupsToFlow_Flow)
        /// </summary>
        [JsonIgnore] 
        public virtual Flow Flow { get; set; } // FK_GroupsToFlow_Flow

        /// <summary>
        /// Parent Group pointed by [GroupsToFlow].([GroupId]) (FK_GroupsToFlow_Groups)
        /// </summary>
        [JsonIgnore] 
        public virtual Group Group { get; set; } // FK_GroupsToFlow_Groups
    }
}
