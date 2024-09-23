namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class EntityNamePlaceholderAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static EntityNamePlaceholderAdminDto FromEntityNamePlaceholder(EntityNamePlaceholder? toDoList)
    {
        if (toDoList == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = toDoList.Id,

            // EntityToDtoPropertyPlaceholder
            // Title = toDoList.Title,
            // ToDoList = toDoList.ToDoList,
        };
    }

    public static EntityNamePlaceholder ToEntityNamePlaceholder(ApplicationUser applicationUser, EntityNamePlaceholderAdminDto toDoListAdminDto)
    {
        return new EntityNamePlaceholder
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = toDoListAdminDto.Id,

            // DtoToEntityPropertyPlaceholder
            // Title = toDoListAdminDto.Title,
            // ToDoList = toDoListAdminDto.ToDoList,
        };
    }
}
