namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

public class ToDoItemAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public bool IsCompleted { get; set; }
    // DtoPropertyPlaceholder

    public static ToDoItemAdminDto FromToDoItem(ToDoItem? toDoItem)
    {
        if (toDoItem == null)
        {
            return new ToDoItemAdminDto();
        }

        return new ToDoItemAdminDto
        {
            Id = toDoItem.Id,

            IsCompleted = toDoItem.IsCompleted,
            // EntityToDtoPlaceholder
        };
    }

    public static ToDoItem ToToDoItem(ApplicationUser? applicationUser, ToDoItemAdminDto? toDoItemAdminDto)
    {
        return new ToDoItem
        {
            ApplicationUserUpdatedBy = applicationUser ?? new ApplicationUser(),
            Id = toDoItemAdminDto?.Id ?? new Guid(),

            IsCompleted = toDoItemAdminDto.IsCompleted,
            // DtoToEntityPropertyPlaceholder
        };
    }
}
