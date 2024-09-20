namespace ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

public class ToDoItemAdminDataTransferObject
{
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder

    public static ToDoItemAdminDataTransferObject FromToDoItem(ToDoItem? toDoItem)
    {
        if (toDoItem == null)
        {
            return new ToDoItemAdminDataTransferObject();
        }

        return new ToDoItemAdminDataTransferObject
        {
            Id = toDoItem.Id,

            Title = toDoItem.Title,
            // EntityToDtoPropertyPlaceholder
        };
    }

    public static ToDoItem ToToDoItem(ApplicationUser applicationUser, ToDoItemAdminDataTransferObject toDoItemAdminDataTransferObject)
    {
        return new ToDoItem
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = toDoItemAdminDataTransferObject.Id,

            // DtoToEntityPropertyPlaceholder
        };
    }
}
