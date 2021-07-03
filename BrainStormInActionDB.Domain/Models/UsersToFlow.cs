using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    public class UsersToFlow
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("flowId")]
        public int FlowId { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }
    }
}
