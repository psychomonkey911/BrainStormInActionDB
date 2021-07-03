using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    public class Flow
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
