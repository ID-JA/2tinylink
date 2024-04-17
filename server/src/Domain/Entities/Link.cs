using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Link : BaseEntity
    {
        public string Address { get; set; }
        public string Url { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public string LockHash { get; set; }
        public string LockSalt { get; set; }

        public Guid? AppUserId { get; set; }
        public AppUser AppUser { get; set;}

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}