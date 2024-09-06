using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Configuration;

public class ApplicationUserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("AspNetUsers", x => x.IsTemporal());

        builder.Property(x => x.Email).IsRequired();

        builder.Property(x => x.NormalizedEmail).IsRequired();

        builder.Property(x => x.NormalizedUserName).IsRequired();

        builder.Property(x => x.UserName).IsRequired();

        builder.HasIndex(x => x.NormalizedUserName).IsUnique();

        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedApplicationUsers)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
