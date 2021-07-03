using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    public class UsersToVideo
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("videoId")]
        public int VideoId { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }
    }
}
