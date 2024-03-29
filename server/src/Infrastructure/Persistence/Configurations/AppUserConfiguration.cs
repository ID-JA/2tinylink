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
            builder.Property(x => x.Id)
            .HasColumnOrder(1);

            builder.Property(x => x.UserName)
           .IsRequired()
           .HasMaxLength(30)
           .HasColumnOrder(2);

            builder.HasIndex(x => x.UserName)
            .IsUnique();

            builder.Property(x => x.FirstName)
           .IsRequired()
           .HasMaxLength(30)
           .HasColumnOrder(3);

            builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnOrder(4);

            builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnOrder(5);

            builder.HasIndex(x => x.Email)
            .IsUnique();

            builder.Property(x => x.EmailConfirmed)
            .IsRequired()
            .HasColumnOrder(6);

            builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasColumnOrder(7);


            builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnOrder(8);

            builder.Property(x => x.LastModified)
            .IsRequired()
            .HasColumnOrder(9);

            builder.Property(x => x.IsActive)
            .IsRequired()
            .HasColumnOrder(10);

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