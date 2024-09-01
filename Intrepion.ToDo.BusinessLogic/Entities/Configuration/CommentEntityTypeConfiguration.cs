using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.ToDo.BusinessLogic.Entities.Configuration;

public class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments", x => x.IsTemporal());

        builder.Property(x => x.Text)
            .IsRequired();

        builder.HasOne(x => x.ApplicationUser)
            .WithMany(x => x.Comments)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedComments)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.BlogPost)
            .WithMany(x => x.Comments)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
