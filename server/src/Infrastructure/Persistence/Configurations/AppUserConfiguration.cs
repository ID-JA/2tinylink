using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasMany(x => x.Projects)
                .WithMany(x => x.AppUsers)
                .UsingEntity<ProjectUser>();

            builder.HasData(SeedDemoUsers());
        }

        private AppUser SeedDemoUsers()
        {
            var defaultPassword = "Pa$$w0rd";
            var user = new AppUser()
            {
                Id = Guid.NewGuid(),
                FirstName = "User",
                LastName = "Demo",
                UserName = "Demo",
                NormalizedUserName = "DEMO",
                Email = "user.demo@2tinylink.com",
                NormalizedEmail = "USER.DEMO@2TINYLINK.COM",
                EmailConfirmed = true
            };

            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            user.PasswordHash = ph.HashPassword(user, defaultPassword);

            return user;
        }
    }
}