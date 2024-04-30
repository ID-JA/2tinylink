using Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class AppUser : IdentityUser<Guid>, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public ICollection<Link> Links { get; set; }
        public ICollection<Project> Projects { get; set; }
        public List<ProjectUser> ProjectUsers { get; } = [];

    }
}