namespace Intrepion.ToDo.BusinessLogic.Entities;

public class Comment
{
    public ApplicationUser? ApplicationUser { get; set; }
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public BlogPost? BlogPost { get; set; }
    public DateTime Date { get; set; }
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
}
