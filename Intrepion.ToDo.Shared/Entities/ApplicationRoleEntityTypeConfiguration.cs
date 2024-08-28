using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppNamePlaceholder.Shared.Entities;

public class ApplicationRoleEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.NormalizedName)
            .IsRequired();

        builder.HasIndex(x => x.NormalizedName)
            .IsUnique();
    }
}
