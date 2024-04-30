using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Link : BaseEntity
    {
        public string Address { get; private set; } // change this to Url
        public string Url { get; private set; } // change this to Key (e.g : '/dix103')
        public DateTime? ExpiredAt { get; private set; }
        public string LockHash { get; private set; }
        public string LockSalt { get; private set; }

        public int Clicks { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool Archived { get; set; }


        public Guid? AppUserId { get; private set; }
        public AppUser AppUser { get; private set;}

        public Guid ProjectId { get; private set; }
        public Project Project { get; private set; }

        public static Link Create(string address, string url, DateTime expiredTime, Guid userId, Guid projectId)
        {
            return new Link
            {
                Url = url,
                Address = address,
                ExpiredAt = expiredTime,
                AppUserId = userId,
                ProjectId = projectId
            };
        }
    }
}