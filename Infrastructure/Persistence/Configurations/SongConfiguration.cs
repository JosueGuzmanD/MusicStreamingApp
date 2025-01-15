using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class SongConfiguration : BaseEntityConfiguration<Song>
{
    public override void Configure(EntityTypeBuilder<Song> builder)
    {
        base.Configure(builder);

        builder.Property(s => s.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(s => s.ImageUrl)
            .HasMaxLength(500);

        builder.Property(s => s.Explicit)
            .IsRequired();

        builder.Property(s => s.Streams)
            .IsRequired()
            .HasDefaultValue(0);
        
        builder.OwnsOne(s=>s.Duration).ConfigureDuration();
    }
}