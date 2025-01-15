using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ListeningHistoryConfiguration : BaseEntityConfiguration<ListeningHistory>
{
    public override void Configure(EntityTypeBuilder<ListeningHistory> builder)
    {
        base.Configure(builder);

        builder.HasOne(lh => lh.User)
            .WithMany()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(lh => lh.Song)
            .WithMany()
            .HasForeignKey("SongId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(lh => lh.PlayedAt)
            .IsRequired();
    }
}