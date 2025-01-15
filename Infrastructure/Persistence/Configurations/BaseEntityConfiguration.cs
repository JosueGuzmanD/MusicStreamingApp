using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
       
        builder.HasIndex("Id");
        
        builder.Property("Id").HasColumnName(typeof(T).Name+ "Id");
        
        builder.Property("CreationDate")
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");
        
        
        builder.Property<bool>("IsDeleted").HasDefaultValue(false);
        builder.HasQueryFilter(e => EF.Property<bool>(e, "IsDeleted") == false);

        
    }
}