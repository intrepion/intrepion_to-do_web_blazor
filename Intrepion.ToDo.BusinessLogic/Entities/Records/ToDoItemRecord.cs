namespace Intrepion.ToDo.BusinessLogic.Entities.Records;

public class ToDoItemRecord
{
    public DateTime CompletedDateTime { get; set; }
    public bool IsCompleted { get; set; }
    public int Ordering { get; set; }
    public string ToDoList_NormalizedTitle { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    // RecordPropertyCodePlaceholder
}
