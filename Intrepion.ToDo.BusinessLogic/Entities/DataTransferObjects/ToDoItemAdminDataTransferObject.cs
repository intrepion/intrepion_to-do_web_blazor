namespace ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

public class EntityNamePlaceholderAdminDataTransferObject
{
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder

    public static EntityNamePlaceholderAdminDataTransferObject FromEntityNamePlaceholder(EntityNamePlaceholder? toDoItem)
    {
        if (toDoItem == null)
        {
            return new EntityNamePlaceholderAdminDataTransferObject();
        }

        return new EntityNamePlaceholderAdminDataTransferObject
        {
            Id = toDoItem.Id,

            // EntityToDtoPropertyPlaceholder
        };
    }

    public static EntityNamePlaceholder ToEntityNamePlaceholder(ApplicationUser applicationUser, EntityNamePlaceholderAdminDataTransferObject toDoItemAdminDataTransferObject)
    {
        return new EntityNamePlaceholder
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = toDoItemAdminDataTransferObject.Id,

            // DtoToEntityPropertyPlaceholder
        };
    }
}
