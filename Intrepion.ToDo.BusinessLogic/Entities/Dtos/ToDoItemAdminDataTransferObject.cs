namespace Intrepion.ToDo.BusinessLogic.Entities.Dtos;

public class ToDoItemAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public ToDoList? ToDoList { get; set; }
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

            Title = toDoItem.Title,
            ToDoList = toDoItem.ToDoList,
            // EntityToDtoPropertyPlaceholder
        };
    }

    public static ToDoItem ToToDoItem(ApplicationUser applicationUser, ToDoItemAdminDto toDoItemAdminDto)
    {
        return new ToDoItem
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = toDoItemAdminDto.Id,

            Title = toDoItemAdminDto.Title,
            ToDoList = toDoItemAdminDto.ToDoList,
            // DtoToEntityPropertyPlaceholder
        };
    }
}
