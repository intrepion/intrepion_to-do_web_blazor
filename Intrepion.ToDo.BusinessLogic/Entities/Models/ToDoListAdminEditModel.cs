using Intrepion.ToDo.BusinessLogic.Entities.Dtos;

namespace Intrepion.ToDo.BusinessLogic.Entities.Models;

public class ToDoListAdminEditModel
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static ToDoListAdminEditModel FromToDoListAdminDto(ToDoListAdminDto toDoListAdminDto)
    {
        if (toDoListAdminDto == null)
        {
            return new ToDoListAdminEditModel();
        }

        return new ToDoListAdminEditModel
        {
            Id = toDoListAdminDto.Id,

            Title = toDoListAdminDto.Title,
            // DtoToModelPlaceholder
            // Title = toDoListAdminDto.Title,
            // ToDoList = toDoListAdminDto.ToDoList,
        };
    }

    public static ToDoListAdminDto ToToDoListAdminDto(ToDoListAdminEditModel toDoListAdminEditModel)
    {
        if (toDoListAdminEditModel == null)
        {
            return new ToDoListAdminDto();
        }

        return new ToDoListAdminDto
        {
            Id = toDoListAdminEditModel.Id,

            Title = toDoListAdminEditModel.Title,
            // ModelToDtoPlaceholder
            // Title = toDoListAdminEditModel.Title,
            // ToDoList = toDoListAdminEditModel.ToDoList,
        };
    }
}
