using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    public class Group
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
