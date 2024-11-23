﻿using System.ComponentModel.DataAnnotations;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class ToDoList
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }
    public DateTime CreateDateTime { get; set; }
    public ICollection<ToDoItem> ToDoItems { get; set; } = [];
    // ActualPropertyPlaceholder
}
