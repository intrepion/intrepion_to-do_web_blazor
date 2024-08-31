namespace Intrepion.ToDo.BusinessLogic.Entities;

public class Comment
{
    public BlogPost? BlogPost { get; set; }
    public DateTime? Date { get; set; }
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? Text { get; set; }
}
