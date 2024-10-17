using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class ToDoItemAdminEditModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder

    public static ToDoItemAdminEditModel FromToDoItemAdminDto(ToDoItemAdminDto toDoItemAdminDto)
    {
        if (toDoItemAdminDto == null)
        {
            return new ToDoItemAdminEditModel();
        }

        return new ToDoItemAdminEditModel
        {
            Id = toDoItemAdminDto.Id,

            // DtoToModelPlaceholder
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

            // ModelToDtoPlaceholder
        };
    }
}
