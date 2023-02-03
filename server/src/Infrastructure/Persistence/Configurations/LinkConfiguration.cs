using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class LinkConfiguration : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.ToTable("LINKS");

            builder.Property(x => x.OriginalUrl)
            .IsRequired();

            builder.Property(x => x.Uri)
            .IsRequired();

            builder.Property(x => x.LockHash)
            .IsRequired(false);

            builder.Property(x => x.LockSalt)
            .IsRequired(false);

            builder.Property(x => x.ExpiredAt)
            .IsRequired(false);

        }
    }
}