using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.Property(x => x.UserName)
            .IsRequired()
            .HasMaxLength(30);

            builder.Property(x => x.PasswordHash)
            .IsRequired();

            builder.Property(x => x.Email)
            .IsRequired();

            builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(30); 

            builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(30);         
        }
    }
}