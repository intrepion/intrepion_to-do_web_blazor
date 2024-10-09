namespace Intrepion.ToDo.BusinessLogic.Entities;

public class ToDoList
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public ICollection<ToDoItem> ToDoItem { get; set; } = [];
    public string Title { get; set; } = string.Empty;
    public string NormalizedTitle { get; set; } = string.Empty;
    // ActualPropertyPlaceholder
}
