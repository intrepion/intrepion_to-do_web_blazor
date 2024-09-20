using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class EntityNamePlaceholderAdminEditModel
{
    public Guid Id { get; set; }

    // ModelPropertyPlaceholder

    public static EntityNamePlaceholderAdminEditModel FromEntityNamePlaceholderAdminDataTransferObject(EntityNamePlaceholderAdminDataTransferObject? toDoItemAdminDataTransferObject)
    {
        if (toDoItemAdminDataTransferObject == null)
        {
            return new EntityNamePlaceholderAdminEditModel();
        }

        return new EntityNamePlaceholderAdminEditModel
        {
            Id = toDoItemAdminDataTransferObject.Id,

            // DtoToModelPropertyPlaceholder
        };
    }

    public static EntityNamePlaceholderAdminDataTransferObject ToEntityNamePlaceholderAdminDataTransferObject(EntityNamePlaceholderAdminEditModel? toDoItemAdminEditModel)
    {
        if (toDoItemAdminEditModel == null)
        {
            return new EntityNamePlaceholderAdminDataTransferObject();
        }

        return new EntityNamePlaceholderAdminDataTransferObject
        {
            Id = toDoItemAdminEditModel.Id,

            // ModelToDtoPropertyPlaceholder
        };
    }
}
