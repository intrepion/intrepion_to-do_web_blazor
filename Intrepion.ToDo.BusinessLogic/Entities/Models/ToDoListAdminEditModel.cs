using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class EntityNamePlaceholderAdminEditModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static EntityNamePlaceholderAdminEditModel FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto toDoListAdminDto)
    {
        if (toDoListAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditModel();
        }

        return new EntityNamePlaceholderAdminEditModel
        {
            Id = toDoListAdminDto.Id,

            // DtoToModelPropertyPlaceholder
            // Title = toDoListAdminDto.Title,
            // ToDoList = toDoListAdminDto.ToDoList,
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditModel toDoListAdminEditModel)
    {
        if (toDoListAdminEditModel == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = toDoListAdminEditModel.Id,

            // ModelToDtoPropertyPlaceholder
            // Title = toDoListAdminEditModel.Title,
            // ToDoList = toDoListAdminEditModel.ToDoList,
        };
    }
}
