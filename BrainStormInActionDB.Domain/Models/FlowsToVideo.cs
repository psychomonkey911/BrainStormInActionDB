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
        /// Parent Flow pointed by [FlowsToVideo].([FlowId]) (FK_FlowsToVideo_Flow)
        /// </summary>
        public virtual Flow Flow { get; set; } // FK_FlowsToVideo_Flow

        /// <summary>
        /// Parent Video pointed by [FlowsToVideo].([VideoId]) (FK_FlowsToVideo_Video)
        /// </summary>
        public virtual Video Video { get; set; } // FK_FlowsToVideo_Video
    }
}
