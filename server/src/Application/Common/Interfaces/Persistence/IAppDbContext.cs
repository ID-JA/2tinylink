using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces.Persistence
{
    public interface IAppDbContext
    {
        public DbSet<TinyLink> TinyLinks { get; }
        public DbSet<AppUser> AppUsers { get; }
        public DbSet<Project> Projects { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}