using Intrepion.ToDo.BusinessLogic.Entities.Dtos;

namespace Intrepion.ToDo.BusinessLogic.Entities.Models;

public class ToDoListAdminEditModel
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    // ModelPropertyPlaceholder

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
            // DtoToModelPropertyPlaceholder
        };
    }

    public static ToDoListAdminDto ToToDoListAdminDto(ToDoListAdminEditModel? toDoListAdminEditModel)
    {
        if (toDoListAdminEditModel == null)
        {
            return new ToDoListAdminDto();
        }

        return new ToDoListAdminDto
        {
            Id = toDoListAdminEditModel.Id,

            Title = toDoListAdminEditModel.Title,
            // ModelToDtoPropertyPlaceholder
        };
    }
}
