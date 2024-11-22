namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Records;

public class ToDoItemRecord
{
    public DateTime CreateDateTime { get; set; }
    public bool IsCompleted { get; set; }
    public int Ordering { get; set; }
    public string ToDoList_NormalizedTitle { get; set; } = string.Empty;
    // RecordPropertyCodePlaceholder
}
