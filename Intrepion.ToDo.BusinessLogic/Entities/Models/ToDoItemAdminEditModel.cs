using Intrepion.ToDo.BusinessLogic.Entities.Dtos;

namespace Intrepion.ToDo.BusinessLogic.Entities.Models;

public class ToDoItemAdminEditModel
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public ToDoList? ToDoList { get; set; }
    // ModelPropertyPlaceholder

    public static ToDoItemAdminEditModel FromToDoItemAdminDto(ToDoItemAdminDto toDoItemAdminDto)
    {
        if (toDoItemAdminDto == null)
        {
            return new ToDoItemAdminEditModel();
        }

        return new ToDoItemAdminEditModel
        {
            Id = toDoItemAdminDto.Id,

            Title = toDoItemAdminDto.Title,
            ToDoList = toDoItemAdminDto.ToDoList,
            // DtoToModelPropertyPlaceholder
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

            Title = toDoItemAdminEditModel.Title,
            ToDoList = toDoItemAdminEditModel.ToDoList,
            // ModelToDtoPropertyPlaceholder
        };
    }
}
