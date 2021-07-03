using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    // FlowsToVideo
    public class FlowsToVideo
    {
        public int FlowId { get; set; } // FlowId (Primary key)
        public int VideoId { get; set; } // VideoId (Primary key)

        // Foreign keys

        /// <summary>
        /// Parent Video pointed by [FlowsToVideo].([VideoId]) (FK_FlowsToVideo_Video)
        /// </summary>
        public virtual Video Video { get; set; } // FK_FlowsToVideo_Video
    }
}
