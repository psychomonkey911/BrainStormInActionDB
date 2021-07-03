using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    public class UsersToGroup
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("groupId")]
        public int GroupId { get; set; }
    }
}
