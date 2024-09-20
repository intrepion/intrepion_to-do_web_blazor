using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class EntityNamePlaceholderAdminEditModel
{
    public Guid Id { get; set; }

    // ModelPropertyPlaceholder

    public static EntityNamePlaceholderAdminEditModel FromEntityNamePlaceholderAdminDataTransferObject(EntityNamePlaceholderAdminDataTransferObject? toDoListAdminDataTransferObject)
    {
        if (toDoListAdminDataTransferObject == null)
        {
            return new EntityNamePlaceholderAdminEditModel();
        }

        return new EntityNamePlaceholderAdminEditModel
        {
            Id = toDoListAdminDataTransferObject.Id,

            // DtoToModelPropertyPlaceholder
        };
    }

    public static EntityNamePlaceholderAdminDataTransferObject ToEntityNamePlaceholderAdminDataTransferObject(EntityNamePlaceholderAdminEditModel? toDoListAdminEditModel)
    {
        if (toDoListAdminEditModel == null)
        {
            return new EntityNamePlaceholderAdminDataTransferObject();
        }

        return new EntityNamePlaceholderAdminDataTransferObject
        {
            Id = toDoListAdminEditModel.Id,

            // ModelToDtoPropertyPlaceholder
        };
    }
}
