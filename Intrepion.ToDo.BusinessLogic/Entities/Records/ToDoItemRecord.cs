namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Records;

public class ToDoItemRecord
{
    public string ApplicationUser_ApplicationUser_NormalizedUserName { get; set; } = string.Empty;
    public DateTime CreateDateTime { get; set; }
    public bool IsCompleted { get; set; }
    public int Ordering { get; set; }
    public string ToDoList_ApplicationUser_NormalizedUserName { get; set; } = string.Empty;
    public string ToDoList_NormalizedTitle { get; set; } = string.Empty;
    public DateTime ToDoList_CreateDateTime { get; set; }
    public string Title { get; set; } = string.Empty;
    // RecordPropertyCodePlaceholder
}
