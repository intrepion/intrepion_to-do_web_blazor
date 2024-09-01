namespace Intrepion.ToDo.BusinessLogic.Entities;

public class BlogPostTag
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public BlogPost? BlogPost { get; set; }
    public Guid BlogPostId { get; set; }
    public Tag? Tag { get; set; }
    public Guid TagId { get; set; }
}
