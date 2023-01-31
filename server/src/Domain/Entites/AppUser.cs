using Domain.Common;

namespace Domain.Entites
{
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public ICollection<Link> Links { get; set; }


    }
}