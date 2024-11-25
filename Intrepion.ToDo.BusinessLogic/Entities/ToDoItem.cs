﻿using System.ComponentModel.DataAnnotations;

namespace Intrepion.ToDo.BusinessLogic.Entities;

public class ToDoItem
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }
    public DateTime CreateDateTime { get; set; }
    public bool IsCompleted { get; set; }
    public int Ordering { get; set; }
    public ToDoList? ToDoList { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string NormalizedTitle { get; set; } = string.Empty;
    // ActualPropertyPlaceholder
}
