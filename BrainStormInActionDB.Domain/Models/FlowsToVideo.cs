using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    public class FlowsToVideo
    {
        [JsonProperty("flowId")]
        public int FlowId { get; set; }

        [JsonProperty("videoId")]
        public int VideoId { get; set; }
    }
}
