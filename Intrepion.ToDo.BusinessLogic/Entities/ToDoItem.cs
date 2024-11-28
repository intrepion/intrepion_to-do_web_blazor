using System.ComponentModel.DataAnnotations;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class ToDoItem
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }
    public DateTime DueDateTime { get; set; }
    public bool IsCompleted { get; set; }
    // ActualPropertyPlaceholder
}
