using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces.Persistence
{
    public interface IAppDbContext
    {
        public DbSet<TinyLink> TinyLinks { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}