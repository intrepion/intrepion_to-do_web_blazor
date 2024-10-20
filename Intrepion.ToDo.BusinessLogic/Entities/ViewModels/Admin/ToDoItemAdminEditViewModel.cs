﻿using Intrepion.ToDo.BusinessLogic.Entities.Dtos.Admin;

namespace Intrepion.ToDo.BusinessLogic.Entities.ViewModels.Admin;

public class ToDoItemAdminEditViewModel
{
    public Guid Id { get; set; }

    public bool IsCompleted { get; set; }
    public int Ordering { get; set; }
    public ToDoList? ToDoList { get; set; }
    public string Title { get; set; } = string.Empty;
    // JustModelPropertyPlaceholder

    public static ToDoItemAdminEditViewModel FromToDoItemAdminDto(ToDoItemAdminDto toDoItemAdminDto)
    {
        if (toDoItemAdminDto == null)
        {
            return new ToDoItemAdminEditViewModel();
        }

        return new ToDoItemAdminEditViewModel
        {
            Id = toDoItemAdminDto.Id,

            IsCompleted = toDoItemAdminDto.IsCompleted,
            Ordering = toDoItemAdminDto.Ordering,
            ToDoList = toDoItemAdminDto.ToDoList,
            Title = toDoItemAdminDto.Title,
            // DtoToModelPlaceholder
        };
    }

    public static ToDoItemAdminDto ToToDoItemAdminDto(ToDoItemAdminEditViewModel toDoItemAdminEditViewModel)
    {
        if (toDoItemAdminEditViewModel == null)
        {
            return new ToDoItemAdminDto();
        }

        return new ToDoItemAdminDto
        {
            Id = toDoItemAdminEditViewModel.Id,

            IsCompleted = toDoItemAdminEditViewModel.IsCompleted,
            Ordering = toDoItemAdminEditViewModel.Ordering,
            ToDoList = toDoItemAdminEditViewModel.ToDoList,
            Title = toDoItemAdminEditViewModel.Title,
            // ModelToDtoPlaceholder
        };
    }
}
