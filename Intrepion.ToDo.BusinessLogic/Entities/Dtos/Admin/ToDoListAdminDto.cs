namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

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

            // EntityToDtoPlaceholder
        };
    }

    public static ToDoList ToToDoList(ApplicationUser? applicationUser, ToDoListAdminDto? toDoListAdminDto)
    {
        return new ToDoList
        {
            ApplicationUserUpdatedBy = applicationUser ?? new ApplicationUser(),
            Id = toDoListAdminDto?.Id ?? new Guid(),

            // DtoToEntityPropertyPlaceholder
        };
    }
}
