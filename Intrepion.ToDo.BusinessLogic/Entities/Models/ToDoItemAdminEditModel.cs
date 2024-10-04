using Intrepion.ToDo.BusinessLogic.Entities.Dtos;

namespace Intrepion.ToDo.BusinessLogic.Entities.Models;

public class ToDoItemAdminEditModel
{
    public Guid Id { get; set; }

    public bool IsCompleted { get; set; }
    public int Ordering { get; set; }
    public ToDoList? ToDoList { get; set; }
    public string Title { get; set; } = string.Empty;
    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static ToDoItemAdminEditModel FromToDoItemAdminDto(ToDoItemAdminDto toDoItemAdminDto)
    {
        if (toDoItemAdminDto == null)
        {
            return new ToDoItemAdminEditModel();
        }

        return new ToDoItemAdminEditModel
        {
            Id = toDoItemAdminDto.Id,

            IsCompleted = toDoItemAdminDto.IsCompleted,
            Ordering = toDoItemAdminDto.Ordering,
            ToDoList = toDoItemAdminDto.ToDoList,
            Title = toDoItemAdminDto.Title,
            // DtoToModelPlaceholder
            // Title = toDoItemAdminDto.Title,
            // ToDoList = toDoItemAdminDto.ToDoList,
        };
    }

    public static ToDoItemAdminDto ToToDoItemAdminDto(ToDoItemAdminEditModel toDoItemAdminEditModel)
    {
        if (toDoItemAdminEditModel == null)
        {
            return new ToDoItemAdminDto();
        }

        return new ToDoItemAdminDto
        {
            Id = toDoItemAdminEditModel.Id,

            IsCompleted = toDoItemAdminEditModel.IsCompleted,
            Ordering = toDoItemAdminEditModel.Ordering,
            ToDoList = toDoItemAdminEditModel.ToDoList,
            Title = toDoItemAdminEditModel.Title,
            // ModelToDtoPlaceholder
            // Title = toDoItemAdminEditModel.Title,
            // ToDoList = toDoItemAdminEditModel.ToDoList,
        };
    }
}
