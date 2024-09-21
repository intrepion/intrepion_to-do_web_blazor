namespace Intrepion.ToDo.BusinessLogic.Entities.Dtos;

public class ToDoListAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    // DtoPropertyPlaceholder

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
        };
    }
}
