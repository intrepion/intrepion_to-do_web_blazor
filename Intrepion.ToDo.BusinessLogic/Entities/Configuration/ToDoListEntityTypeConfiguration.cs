using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Configuration;

public class EntityNamePlaceholderEntityTypeConfiguration : IEntityTypeConfiguration<EntityNamePlaceholder>
{
    public void Configure(EntityTypeBuilder<EntityNamePlaceholder> builder)
    {
        builder.ToTable("TableNamePlaceholder", x => x.IsTemporal());

        // builder.Property(x => x.PropertyNamePlaceholder);

        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedTableNamePlaceholder)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
