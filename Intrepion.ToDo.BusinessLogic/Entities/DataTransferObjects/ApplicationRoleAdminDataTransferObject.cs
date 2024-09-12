namespace ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

public class ApplicationRoleAdminDataTransferObject
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public static ApplicationRoleAdminDataTransferObject FromApplicationRole(ApplicationRole? applicationRole)
    {
        if (applicationRole == null)
        {
            return new ApplicationRoleAdminDataTransferObject();
        }

        return new ApplicationRoleAdminDataTransferObject
        {
            Id = applicationRole.Id,
            Name = applicationRole.Name ?? string.Empty,
        };
    }

    public static ApplicationRole ToApplicationRole(ApplicationRoleAdminDataTransferObject applicationRoleAdminDataTransferObject)
    {
        return new ApplicationRole
        {
            Id = applicationRoleAdminDataTransferObject.Id,
            Name = applicationRoleAdminDataTransferObject.Name,
        };
    }
}
