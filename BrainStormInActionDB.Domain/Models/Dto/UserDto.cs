using System.Collections;
using System.Collections.Generic;

namespace BrainStormInActionDB.Domain.Models.Dto
{
    // UserDto
    public class UserDto
    {
        public int Id { get; set; } // Id (Primary key)
        public ICollection<int> VideosId { get; set; }
    }
}
