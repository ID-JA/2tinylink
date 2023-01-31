using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("APP_USERS");

            builder.Property(x => x.UserName)
            .IsRequired();

            builder.Property(x => x.Email)
            .IsRequired();

            builder.Property(x => x.PasswordHash)
            .IsRequired();

            builder.Property(x => x.PasswordSalt)
            .IsRequired();
            
        }
    }
}