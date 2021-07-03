using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    public class GroupsToFlow
    {
        [JsonProperty("groupId")]
        public int GroupId { get; set; }

        [JsonProperty("flowId")]
        public int FlowId { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }
    }
}
