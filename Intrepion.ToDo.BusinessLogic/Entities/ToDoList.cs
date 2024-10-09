﻿namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class ToDoList
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public ICollection<ToDoItem> ToDoItem { get; set; } = [];
    // ActualPropertyPlaceholder
}
