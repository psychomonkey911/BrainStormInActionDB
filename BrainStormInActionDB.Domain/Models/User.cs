using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BrainStormInActionDB.Domain.Models
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
