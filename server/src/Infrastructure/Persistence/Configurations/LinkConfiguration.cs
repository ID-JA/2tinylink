using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class LinkConfiguration : IEntityTypeConfiguration<TinyLink>
    {
        public void Configure(EntityTypeBuilder<TinyLink> builder)
        {
            builder.ToTable("TINY_LINKS");

            builder.Property(x => x.Address)
            .IsRequired();

            builder.Property(x => x.Url)
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