using Intrepion.ToDo.BusinessLogic.Entities;
using Intrepion.ToDo.BusinessLogic.Entities.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.ToDo.BusinessLogic.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>(options)
{
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<BlogPost> BlogPostTags { get; set; }
    public DbSet<BlogPost> Categories { get; set; }
    public DbSet<BlogPost> Comments { get; set; }
    public DbSet<BlogPost> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        new ApplicationRoleClaimEntityTypeConfiguration().Configure(builder.Entity<ApplicationRoleClaim>());
        new ApplicationRoleEntityTypeConfiguration().Configure(builder.Entity<ApplicationRole>());
        new ApplicationUserEntityTypeConfiguration().Configure(builder.Entity<ApplicationUser>());
        new ApplicationUserClaimEntityTypeConfiguration().Configure(builder.Entity<ApplicationUserClaim>());
        new ApplicationUserLoginEntityTypeConfiguration().Configure(builder.Entity<ApplicationUserLogin>());
        new ApplicationUserRoleEntityTypeConfiguration().Configure(builder.Entity<ApplicationUserRole>());
        new ApplicationUserTokenEntityTypeConfiguration().Configure(builder.Entity<ApplicationUserToken>());
        new BlogPostEntityTypeConfiguration().Configure(builder.Entity<BlogPost>());
        new BlogPostTagEntityTypeConfiguration().Configure(builder.Entity<BlogPostTag>());
        new CategoryEntityTypeConfiguration().Configure(builder.Entity<Category>());
        new CommentEntityTypeConfiguration().Configure(builder.Entity<Comment>());
        new TagEntityTypeConfiguration().Configure(builder.Entity<Tag>());
    }
}
