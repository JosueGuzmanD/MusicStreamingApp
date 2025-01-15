using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ArtistConfiguration : BaseEntityConfiguration<Artist>
{
    public override void Configure(EntityTypeBuilder<Artist> builder)
    {
        base.Configure(builder);

        builder.Property(a => a.ArtistName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(a => a.ArtistDescription)
            .HasMaxLength(1000);

        builder.Property(a => a.ArtistImage)
            .HasMaxLength(500);

        builder.HasMany(a => a.Albums)
            .WithOne()
            .HasForeignKey(a => a.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
