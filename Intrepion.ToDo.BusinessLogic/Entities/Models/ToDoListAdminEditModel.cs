using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class EntityNamePlaceholderAdminEditModel
{
    public Guid Id { get; set; }

    // ModelPropertyPlaceholder

    public static EntityNamePlaceholderAdminEditModel FromEntityNamePlaceholderAdminDataTransferObject(EntityNamePlaceholderAdminDataTransferObject? EntityLowercaseNamePlaceholderAdminDataTransferObject)
    {
        if (EntityLowercaseNamePlaceholderAdminDataTransferObject == null)
        {
            return new EntityNamePlaceholderAdminEditModel();
        }

        return new EntityNamePlaceholderAdminEditModel
        {
            Id = EntityLowercaseNamePlaceholderAdminDataTransferObject.Id,

            // DtoToModelPropertyPlaceholder
        };
    }

    public static EntityNamePlaceholderAdminDataTransferObject ToEntityNamePlaceholderAdminDataTransferObject(EntityNamePlaceholderAdminEditModel? EntityLowercaseNamePlaceholderAdminEditModel)
    {
        if (EntityLowercaseNamePlaceholderAdminEditModel == null)
        {
            return new EntityNamePlaceholderAdminDataTransferObject();
        }

        return new EntityNamePlaceholderAdminDataTransferObject
        {
            Id = EntityLowercaseNamePlaceholderAdminEditModel.Id,

            // ModelToDtoPropertyPlaceholder
        };
    }
}
