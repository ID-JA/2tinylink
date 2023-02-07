using Domain.Common;

namespace Domain.Entites
{
    public class TinyLink : BaseEntity
    {
        public string Address { get; set; }
        public string Url { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public string LockHash { get; set; }
        public string LockSalt { get; set; }

        // relations
        public Guid? AppUserId { get; set; }
    }
}