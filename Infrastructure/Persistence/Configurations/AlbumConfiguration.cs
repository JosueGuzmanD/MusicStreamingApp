using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AlbumConfiguration : BaseEntityConfiguration<Album>
{
    public override void Configure(EntityTypeBuilder<Album> builder)
    {
        base.Configure(builder);

        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(a => a.ImageUrl)
            .HasMaxLength(500);

        builder.HasMany(a => a.Songs)
            .WithOne()
            .HasForeignKey(s => s.AlbumId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.OwnsOne(a => a.Duration).ConfigureDuration();
    }
}