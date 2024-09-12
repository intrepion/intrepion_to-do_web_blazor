using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class ApplicationUserAdminEditModel
{
    public List<ApplicationRoleAdminEditModel> ApplicationRoles { get; set; } = [];
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public static ApplicationUserAdminEditModel FromApplicationUserAdminDataTransferObject(ApplicationUserAdminDataTransferObject? applicationUserAdminDataTransferObject)
    {
        if (applicationUserAdminDataTransferObject == null)
        {
            return new ApplicationUserAdminEditModel();
        }

        var applicationUserAdminEditModel = new ApplicationUserAdminEditModel
        {
            ApplicationRoles = applicationUserAdminDataTransferObject.ApplicationRoles.Select(x => new ApplicationRoleAdminEditModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList(),
            Email = applicationUserAdminDataTransferObject.Email,
            Id = applicationUserAdminDataTransferObject.Id,
            PhoneNumber = applicationUserAdminDataTransferObject.PhoneNumber,
            UserName = applicationUserAdminDataTransferObject.UserName,
        };

        return applicationUserAdminEditModel;
    }

    public static ApplicationUserAdminDataTransferObject ToApplicationUserAdminDataTransferObject(ApplicationUserAdminEditModel? applicationUserAdminEditModel)
    {
        if (applicationUserAdminEditModel == null)
        {
            return new ApplicationUserAdminDataTransferObject();
        }

        var applicationUser = new ApplicationUserAdminDataTransferObject
        {
            ApplicationRoles = applicationUserAdminEditModel.ApplicationRoles.Select(x => new ApplicationRoleAdminDataTransferObject
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList(),
            Email = applicationUserAdminEditModel.Email,
            Id = applicationUserAdminEditModel.Id,
            PhoneNumber = applicationUserAdminEditModel.PhoneNumber,
            UserName = applicationUserAdminEditModel.UserName,
        };

        return applicationUser;
    }
}
