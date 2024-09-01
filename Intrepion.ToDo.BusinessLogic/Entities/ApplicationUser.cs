using Microsoft.AspNetCore.Identity;

namespace Intrepion.ToDo.BusinessLogic.Entities;

public class ApplicationUser : IdentityUser
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public ICollection<BlogPost> BlogPosts { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<ApplicationRole> UpdatedApplicationRoles { get; set; } = [];
    public ICollection<ApplicationRoleClaim> UpdatedApplicationRoleClaims { get; set; } = [];
    public ICollection<ApplicationUser> UpdatedApplicationUsers { get; set; } = [];
    public ICollection<ApplicationUserClaim> UpdatedApplicationUserClaims { get; set; } = [];
    public ICollection<ApplicationUserLogin> UpdatedApplicationUserLogins { get; set; } = [];
    public ICollection<ApplicationUserRole> UpdatedApplicationUserRoles { get; set; } = [];
    public ICollection<ApplicationUserToken> UpdatedApplicationUserTokens { get; set; } = [];
    public ICollection<BlogPost> UpdatedBlogPosts { get; set; } = [];
    public ICollection<BlogPostTag> UpdatedBlogPostTags { get; set; } = [];
    public ICollection<Category> UpdatedCategories { get; set; } = [];
    public ICollection<Comment> UpdatedComments { get; set; } = [];
    public ICollection<Tag> UpdatedTags { get; set; } = [];
}
