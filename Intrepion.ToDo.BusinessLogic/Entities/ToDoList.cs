﻿namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class ToDoList
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public List<ToDoItem>? ToDoItems { get; set; } = [];
    // ActualPropertyPlaceholder
}
