namespace Intrepion.ToDo.BusinessLogic.Entities;

public class Category
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public ICollection<BlogPost> BlogPosts { get; set; } = [];
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
