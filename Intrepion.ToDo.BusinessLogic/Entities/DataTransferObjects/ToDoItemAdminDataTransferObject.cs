namespace ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

public class EntityNamePlaceholderAdminDataTransferObject
{
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder

    public static EntityNamePlaceholderAdminDataTransferObject FromEntityNamePlaceholder(EntityNamePlaceholder? EntityLowercaseNamePlaceholder)
    {
        if (EntityLowercaseNamePlaceholder == null)
        {
            return new EntityNamePlaceholderAdminDataTransferObject();
        }

        return new EntityNamePlaceholderAdminDataTransferObject
        {
            Id = EntityLowercaseNamePlaceholder.Id,

            // EntityToDtoPropertyPlaceholder
        };
    }

    public static EntityNamePlaceholder ToEntityNamePlaceholder(ApplicationUser applicationUser, EntityNamePlaceholderAdminDataTransferObject EntityLowercaseNamePlaceholderAdminDataTransferObject)
    {
        return new EntityNamePlaceholder
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = EntityLowercaseNamePlaceholderAdminDataTransferObject.Id,

            // DtoToEntityPropertyPlaceholder
        };
    }
}
