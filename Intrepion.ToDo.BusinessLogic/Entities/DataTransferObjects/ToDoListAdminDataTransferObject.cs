namespace ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

public class EntityNamePlaceholderAdminDataTransferObject
{
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder

    public static EntityNamePlaceholderAdminDataTransferObject FromEntityNamePlaceholder(EntityNamePlaceholder? toDoList)
    {
        if (toDoList == null)
        {
            return new EntityNamePlaceholderAdminDataTransferObject();
        }

        return new EntityNamePlaceholderAdminDataTransferObject
        {
            Id = toDoList.Id,

            // EntityToDtoPropertyPlaceholder
        };
    }

    public static EntityNamePlaceholder ToEntityNamePlaceholder(ApplicationUser applicationUser, EntityNamePlaceholderAdminDataTransferObject toDoListAdminDataTransferObject)
    {
        return new EntityNamePlaceholder
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = toDoListAdminDataTransferObject.Id,

            // DtoToEntityPropertyPlaceholder
        };
    }
}
