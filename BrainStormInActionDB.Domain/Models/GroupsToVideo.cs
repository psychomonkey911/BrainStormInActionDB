using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    public class GroupsToVideo
    {
        [JsonProperty("groupId")]
        public int GroupId { get; set; }

        [JsonProperty("videoId")]
        public int VideoId { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }
    }
}
