namespace ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

public class ApplicationUserAdminDataTransferObject
{
    public ICollection<ApplicationRoleAdminDataTransferObject> ApplicationRoles { get; set; } = [];
    public string Email { get; set; } = string.Empty;
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public static ApplicationUserAdminDataTransferObject FromApplicationUser(ApplicationUser? applicationUser)
    {
        if (applicationUser == null)
        {
            return new ApplicationUserAdminDataTransferObject();
        }

        var applicationRoleAdminDataTransferObjects = applicationUser.ApplicationUserRoles.Select(x => ApplicationRoleAdminDataTransferObject.FromApplicationRole(x.ApplicationRole)).ToList();

        return new ApplicationUserAdminDataTransferObject
        {
            ApplicationRoles = applicationRoleAdminDataTransferObjects,
            Email = applicationUser.Email ?? string.Empty,
            Id = applicationUser.Id,
            PhoneNumber = applicationUser.PhoneNumber ?? string.Empty,
            UserName = applicationUser.UserName ?? string.Empty,
        };
    }

    public static ApplicationUser ToApplicationUser(ApplicationUserAdminDataTransferObject applicationUserAdminDataTransferObject)
    {
        var applicationUser = new ApplicationUser
        {
            Email = applicationUserAdminDataTransferObject.Email,
            Id = applicationUserAdminDataTransferObject.Id,
            PhoneNumber = applicationUserAdminDataTransferObject.PhoneNumber,
            UserName = applicationUserAdminDataTransferObject.UserName,
        };

        applicationUser.ApplicationUserRoles = applicationUserAdminDataTransferObject.ApplicationRoles.Select(x => new ApplicationUserRole
        {
            ApplicationRole = new ApplicationRole
            {
                Id = x.Id,
                Name = x.Name,
            },
            ApplicationUser = applicationUser,
        }).ToList();

        return applicationUser;
    }
}
