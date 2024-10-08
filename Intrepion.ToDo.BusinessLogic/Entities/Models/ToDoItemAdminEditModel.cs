using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class ToDoItemAdminEditModel
{
    public Guid Id { get; set; }

    public bool IsCompleted { get; set; }
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
            // ModelToDtoPlaceholder
            // Title = toDoItemAdminEditModel.Title,
            // ToDoList = toDoItemAdminEditModel.ToDoList,
        };
    }
}
