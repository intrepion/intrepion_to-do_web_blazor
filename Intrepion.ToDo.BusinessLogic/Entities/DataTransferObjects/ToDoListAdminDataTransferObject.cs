namespace ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

public class ToDoListAdminDataTransferObject
{
    public Guid Id { get; set; }

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

            // EntityToDtoPropertyPlaceholder
        };
    }

    public static ToDoList ToToDoList(ApplicationUser applicationUser, ToDoListAdminDataTransferObject toDoListAdminDataTransferObject)
    {
        return new ToDoList
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = toDoListAdminDataTransferObject.Id,

            // DtoToEntityPropertyPlaceholder
        };
    }
}
