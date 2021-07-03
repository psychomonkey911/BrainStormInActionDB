namespace BrainStormInActionDB.Domain.Models.Dto
{
    // UsersToVideo
    public class UsersToVideoDto
    {
        public int UserId { get; set; } // UserId (Primary key)
        public int VideoId { get; set; } // VideoId (Primary key)
        public string Priority { get; set; } // Priority (Primary key) (length: 50)
    }
}
