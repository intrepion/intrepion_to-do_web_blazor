using AppNamePlaceholder.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppNamePlaceholder.Shared.Entities.Configuration;

public class ApplicationUserRoleEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
{
    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
    {
        builder
            .ToTable("AspNetUserRoles", x => x.IsTemporal());

        builder
            .HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedApplicationUserRoles)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
