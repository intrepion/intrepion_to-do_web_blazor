using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.ToDo.BusinessLogic.Entities.Configuration;

public class BlogPostTagEntityTypeConfiguration : IEntityTypeConfiguration<BlogPostTag>
{
    public void Configure(EntityTypeBuilder<BlogPostTag> builder)
    {
        builder.ToTable("BlogPostTags", x => x.IsTemporal());

        builder.HasKey(x => new { x.BlogPostId, x.TagId });

        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedBlogPostTags)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.BlogPost)
            .WithMany(x => x.BlogPostTags)
            .HasForeignKey(x => x.BlogPostId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Tag)
            .WithMany(x => x.BlogPostTags)
            .HasForeignKey(x => x.TagId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
