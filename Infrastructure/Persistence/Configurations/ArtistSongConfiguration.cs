using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ArtistSongConfiguration: IEntityTypeConfiguration<ArtistSong>
{
    public void Configure(EntityTypeBuilder<ArtistSong> builder)
    {
        builder.HasKey(asset => new { asset.ArtistId, asset.SongId });
        
        builder.HasOne(a=>a.Artist)
            .WithMany(s=>s.Songs)
            .HasForeignKey(a => a.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(s => s.Song)
            .WithMany(s => s.ArtistSongs)
            .HasForeignKey(s => s.SongId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}