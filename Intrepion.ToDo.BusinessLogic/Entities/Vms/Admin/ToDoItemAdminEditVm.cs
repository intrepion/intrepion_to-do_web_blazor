﻿using System.ComponentModel.DataAnnotations;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Vms.Admin;

public class ToDoItemAdminEditVm
{
    public Guid Id { get; set; }

    public bool IsCompleted { get; set; }
    public int Ordering { get; set; }
    public ToDoList? ToDoList { get; set; }
    // JustModelPropertyPlaceholder

    public static ToDoItemAdminEditVm FromToDoItemAdminDto(ToDoItemAdminDto toDoItemAdminDto)
    {
        if (toDoItemAdminDto == null)
        {
            return new ToDoItemAdminEditVm();
        }

        return new ToDoItemAdminEditVm
        {
            Id = toDoItemAdminDto.Id,

            IsCompleted = toDoItemAdminDto?.IsCompleted ?? false,
            Ordering = toDoItemAdminDto?.Ordering ?? -1,
            ToDoList = toDoItemAdminDto?.ToDoList,
            // DtoToModelPlaceholder
        };
    }

    public static ToDoItemAdminDto ToToDoItemAdminDto(ToDoItemAdminEditVm toDoItemAdminEditVm)
    {
        if (toDoItemAdminEditVm == null)
        {
            return new ToDoItemAdminDto();
        }

        return new ToDoItemAdminDto
        {
            Id = toDoItemAdminEditVm.Id,

            IsCompleted = toDoItemAdminEditVm.IsCompleted,
            Ordering = toDoItemAdminEditVm.Ordering,
            // ModelToDtoPlaceholder
        };
    }
}
