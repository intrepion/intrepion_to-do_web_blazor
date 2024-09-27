﻿namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class ToDoItem
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public ToDoList? ToDoList { get; set; }
    public string Title { get; set; } = string.Empty;
    // ActualPropertyPlaceholder
}
