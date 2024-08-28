using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppNamePlaceholder.Shared.Entities;

public class ApplicationUserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.Email)
            .IsRequired();

        builder.Property(x => x.NormalizedEmail)
            .IsRequired();

        builder.Property(x => x.NormalizedUserName)
            .IsRequired();

        builder.Property(x => x.UserName)
            .IsRequired();

        builder.HasIndex(x => x.NormalizedUserName)
            .IsUnique();
    }
}
