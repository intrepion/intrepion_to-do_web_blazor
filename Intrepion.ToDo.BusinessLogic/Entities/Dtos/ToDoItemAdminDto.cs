namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class ToDoItemAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public bool IsCompleted { get; set; }
    public int Ordering { get; set; }
    public ToDoList? ListItems { get; set; }
    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

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
            ListItems = toDoItem.ListItems,
            // EntityToDtoPlaceholder
            // Title = toDoItem.Title,
            // ToDoList = toDoItem.ToDoList,
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
            ListItems = toDoItemAdminDto.ListItems,
            // DtoToEntityPropertyPlaceholder
            // Title = toDoItemAdminDto.Title,
            // ToDoList = toDoItemAdminDto.ToDoList,
        };
    }
}
