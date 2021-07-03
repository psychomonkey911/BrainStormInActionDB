using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    public class Flow
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
