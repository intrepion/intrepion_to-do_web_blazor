using System.ComponentModel.DataAnnotations;
using Intrepion.ToDo.BusinessLogic.Entities.Dtos.Admin;

namespace Intrepion.ToDo.BusinessLogic.Entities.Vms.Admin;

public class ToDoItemAdminEditVm
{
    public Guid Id { get; set; }

    public bool IsCompleted { get; set; }
    public int Ordering { get; set; }
    public ToDoList? ToDoList { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
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
            Title = toDoItemAdminDto?.Title ?? string.Empty,
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
            ToDoList = toDoItemAdminEditVm.ToDoList,
            Title = toDoItemAdminEditVm.Title,
            // ModelToDtoPlaceholder
        };
    }
}
