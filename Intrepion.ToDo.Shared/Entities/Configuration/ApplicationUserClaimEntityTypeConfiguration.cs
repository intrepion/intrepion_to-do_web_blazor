using Intrepion.ToDo.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.ToDo.Shared.Entities.Configuration;

public class ApplicationUserClaimEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUserClaim>
{
    public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
    {
        builder
            .ToTable("AspNetUserClaims", x => x.IsTemporal());

        builder
            .HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedApplicationUserClaims)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
