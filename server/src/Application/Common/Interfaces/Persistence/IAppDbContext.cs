using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces.Persistence
{
    public interface IAppDbContext
    {
        public DbSet<Link> Links { get; }
        public DbSet<AppUser> AppUsers { get; }
        public DbSet<Project> Projects { get; }
        public DbSet<ProjectInvitation> ProjectInvitations { get; }
        public DbSet<ProjectUser> ProjectUsers { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}