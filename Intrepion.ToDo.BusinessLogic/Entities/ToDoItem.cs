namespace Intrepion.ToDo.BusinessLogic.Entities;

public class ToDoItem
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public bool IsCompleted { get; set; }
    public int Ordering { get; set; }
    public ToDoList? ToDoList { get; set; }
    public string Title { get; set; } = string.Empty;
    public string NormalizedTitle { get; set; } = string.Empty;
    // ActualPropertyPlaceholder
}
