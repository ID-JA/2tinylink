
using Domain.Entites.Common;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entites
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public ICollection<TinyLink> TinyLinks { get; set; }

    }
}