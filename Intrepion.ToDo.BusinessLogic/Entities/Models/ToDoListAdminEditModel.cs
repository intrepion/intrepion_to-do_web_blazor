using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class ToDoListAdminEditModel
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    // JustModelPropertyPlaceholder

    public static ToDoListAdminEditModel FromToDoListAdminDto(ToDoListAdminDto toDoListAdminDto)
    {
        if (toDoListAdminDto == null)
        {
            return new ToDoListAdminEditModel();
        }

        return new ToDoListAdminEditModel
        {
            Id = toDoListAdminDto.Id,

            // DtoToModelPlaceholder
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

            // ModelToDtoPlaceholder
        };
    }
}
