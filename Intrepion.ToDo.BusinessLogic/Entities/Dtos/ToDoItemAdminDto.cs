namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class ToDoItemAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public bool IsCompleted { get; set; }
    public int Ordering { get; set; }
    public ToDoList? ToDoList { get; set; }
    public string Title { get; set; } = string.Empty;
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
            Ordering = toDoItem.Ordering,
            ToDoList = toDoItem.ToDoList,
            Title = toDoItem.Title,
            // EntityToDtoPlaceholder
        };
    }

    public static ToDoItem ToToDoItem(ApplicationUser applicationUser, ToDoItemAdminDto toDoItemAdminDto)
    {
        return new ToDoItem
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = toDoItemAdminDto.Id,

            IsCompleted = toDoItemAdminDto.IsCompleted,
            Ordering = toDoItemAdminDto.Ordering,
            ToDoList = toDoItemAdminDto.ToDoList,
            Title = toDoItemAdminDto.Title,
            // DtoToEntityPropertyPlaceholder
        };
    }
}
