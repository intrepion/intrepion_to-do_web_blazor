using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.ToDo.BusinessLogic.Entities.Configuration;

public class ApplicationUserEtc : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasOne(x => x.ApplicationUserCreatedBy)
            .WithMany(x => x.CreatedApplicationUsers)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedApplicationUsers)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ToDoItems)
            .WithOne(x => x.ApplicationUser)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.ToDoLists)
            .WithOne(x => x.ApplicationUser)
            .OnDelete(DeleteBehavior.Restrict);
        // EntityConfigurationCodePlaceholder
    }
}
