namespace Intrepion.ToDo.BusinessLogic.Entities.DataTransferObjects;

public class ToDoListAdminDataTransferObject
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    // DtoPropertyPlaceholder

    public static ToDoListAdminDataTransferObject FromToDoList(ToDoList? toDoList)
    {
        if (toDoList == null)
        {
            return new ToDoListAdminDataTransferObject();
        }

        return new ToDoListAdminDataTransferObject
        {
            Id = toDoList.Id,

            Title = toDoList.Title,
            // EntityToDtoPropertyPlaceholder
        };
    }

    public static ToDoList ToToDoList(ApplicationUser applicationUser, ToDoListAdminDataTransferObject toDoListAdminDataTransferObject)
    {
        return new ToDoList
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = toDoListAdminDataTransferObject.Id,

            Title = toDoListAdminDataTransferObject.Title,
            // DtoToEntityPropertyPlaceholder
        };
    }
}
