namespace Intrepion.ToDo.BusinessLogic.Entities.Dtos;

public class ToDoListAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public List<ToDoItem>? ToDoItems { get; set; } = [];
    public string Title { get; set; } = string.Empty;
    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static ToDoListAdminDto FromToDoList(ToDoList? toDoList)
    {
        if (toDoList == null)
        {
            return new ToDoListAdminDto();
        }

        return new ToDoListAdminDto
        {
            Id = toDoList.Id,

            Title = toDoList.Title,
            // EntityToDtoPropertyPlaceholder
            // Title = toDoList.Title,
            // ToDoList = toDoList.ToDoList,
        };
    }

    public static ToDoList ToToDoList(ApplicationUser applicationUser, ToDoListAdminDto toDoListAdminDto)
    {
        return new ToDoList
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = toDoListAdminDto.Id,

            Title = toDoListAdminDto.Title,
            // DtoToEntityPropertyPlaceholder
            // Title = toDoListAdminDto.Title,
            // ToDoList = toDoListAdminDto.ToDoList,
        };
    }
}
