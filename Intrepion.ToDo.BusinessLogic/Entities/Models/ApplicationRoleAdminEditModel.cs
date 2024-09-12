using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class ApplicationRoleAdminEditModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public static ApplicationRoleAdminEditModel FromApplicationRoleAdminDataTransferObject(ApplicationRoleAdminDataTransferObject? applicationRoleAdminDataTransferObject)
    {
        if (applicationRoleAdminDataTransferObject == null)
        {
            return new ApplicationRoleAdminEditModel();
        }

        return new ApplicationRoleAdminEditModel
        {
            Id = applicationRoleAdminDataTransferObject.Id,
            Name = applicationRoleAdminDataTransferObject.Name,
        };
    }

    public static ApplicationRoleAdminDataTransferObject ToApplicationRoleAdminDataTransferObject(ApplicationRoleAdminEditModel? applicationRoleAdminEditModel)
    {
        if (applicationRoleAdminEditModel == null)
        {
            return new ApplicationRoleAdminDataTransferObject();
        }

        return new ApplicationRoleAdminDataTransferObject
        {
            Id = applicationRoleAdminEditModel.Id,
            Name = applicationRoleAdminEditModel.Name,
        };
    }
}
