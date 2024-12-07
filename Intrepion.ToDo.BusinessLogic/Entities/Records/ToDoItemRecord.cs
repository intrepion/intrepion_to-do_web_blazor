﻿namespace Intrepion.ToDo.BusinessLogic.Entities.Records;

public class ToDoItemRecord
{
    public string ApplicationUser_NormalizedUserName { get; set; } = string.Empty;
    public DateTime DueDateTime { get; set; }
    public bool IsCompleted { get; set; }
    public int Ordering { get; set; }
    public string ToDoList_ApplicationUser_NormalizedUserName { get; set; } = string.Empty;
    public string ToDoList_NormalizedTitle { get; set; } = string.Empty;
    public DateTime ToDoList_DueDateTime { get; set; }
    public string Title { get; set; } = string.Empty;
    // RecordPropertyCodePlaceholder
}
