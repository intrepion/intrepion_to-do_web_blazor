using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class EntityNamePlaceholderAdminEditModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static EntityNamePlaceholderAdminEditModel FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto toDoItemAdminDto)
    {
        if (toDoItemAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditModel();
        }

        return new EntityNamePlaceholderAdminEditModel
        {
            Id = toDoItemAdminDto.Id,

            // DtoToModelPlaceholder
            // Title = toDoItemAdminDto.Title,
            // ToDoList = toDoItemAdminDto.ToDoList,
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditModel toDoItemAdminEditModel)
    {
        if (toDoItemAdminEditModel == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = toDoItemAdminEditModel.Id,

            // ModelToDtoPlaceholder
            // Title = toDoItemAdminEditModel.Title,
            // ToDoList = toDoItemAdminEditModel.ToDoList,
        };
    }
}
