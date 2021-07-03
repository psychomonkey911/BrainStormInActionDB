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
        /// Parent Group pointed by [GroupsToFlow].([GroupId]) (FK_GroupsToFlow_Groups)
        /// </summary>
        public virtual Group Group { get; set; } // FK_GroupsToFlow_Groups
    }
}
