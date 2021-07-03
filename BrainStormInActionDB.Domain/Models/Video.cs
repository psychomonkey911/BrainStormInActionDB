using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    public class Video
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
