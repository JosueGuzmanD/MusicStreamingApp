using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FullName.FirstName)
            .HasMaxLength(50);

        builder.Property(u => u.FullName.LastName)
            .HasMaxLength(50);

        builder.OwnsOne(u => u.Address, address =>
        {
            address.Property(ad => ad.Street).HasMaxLength(100).IsRequired();
            address.Property(ad => ad.City).HasMaxLength(50).IsRequired();
            address.Property(ad => ad.State).HasMaxLength(50);
            address.Property(ad => ad.Country).HasMaxLength(50).IsRequired();
            address.Property(ad => ad.PostalCode).HasMaxLength(10);
        });

        builder.HasMany(u => u.FavouriteSongs)
            .WithMany();

        builder.HasMany(u => u.FollowedArtists)
            .WithMany();
    }
}