using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public static class OwnedTypeConfigurations
{
    public static void ConfigureDuration<TEntity>
        (this OwnedNavigationBuilder<TEntity, Duration> builder)
        where TEntity : class
    {
        builder.Property(d => d.Minutes);
        builder.Property(d => d.Seconds);
    }
    
    
}