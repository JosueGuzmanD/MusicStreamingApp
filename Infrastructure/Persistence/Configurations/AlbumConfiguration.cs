using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AlbumConfiguration: IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasIndex(a=>a.Id);
        builder.Property(a => a.Id).HasColumnName("AlbumId");
        
        
        

    }
}