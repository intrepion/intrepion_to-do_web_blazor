﻿namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class ToDoItem
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public bool IsCompleted { get; set; }
    public int Ordering { get; set; }
    public ToDoList? ListItems { get; set; }
    // ActualPropertyPlaceholder
}
