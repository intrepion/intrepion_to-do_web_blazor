using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.ToDo.BusinessLogic.Entities.Configuration;

public class BlogPostEntityTypeConfiguration : IEntityTypeConfiguration<BlogPost>
{
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        builder.ToTable("BlogPosts", x => x.IsTemporal());

        builder.Property(x => x.Text)
            .IsRequired();

        builder.Property(x => x.Title)
            .IsRequired();

        builder.HasOne(x => x.ApplicationUser)
            .WithMany(x => x.BlogPosts)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedBlogPosts)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.BlogPosts)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
