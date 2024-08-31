namespace Intrepion.ToDo.BusinessLogic.Entities;

public class BlogPost
{
    public Category? Category { get; set; }
    public Guid Id { get; set; }
    public DateTime PublishDate { get; set; }
    public List<Tag> Tags { get; set; } = [];
    public string Text { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
}
