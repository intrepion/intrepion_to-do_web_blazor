namespace Intrepion.ToDo.BusinessLogic.Entities.Dtos;

public class ApplicationUserAdminDto
{
    public ICollection<ApplicationRoleAdminDto> ApplicationRoles { get; set; } = [];
    public string ApplicationUserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public static ApplicationUserAdminDto FromApplicationUser(ApplicationUser? applicationUser)
    {
        if (applicationUser == null)
        {
            return new ApplicationUserAdminDto();
        }

        var applicationRoleAdminDtos = applicationUser.ApplicationUserRoles.Select(x => ApplicationRoleAdminDto.FromApplicationRole(x.ApplicationRole)).ToList();

        return new ApplicationUserAdminDto
        {
            ApplicationRoles = applicationRoleAdminDtos,
            Email = applicationUser.Email ?? string.Empty,
            Id = applicationUser.Id,
            PhoneNumber = applicationUser.PhoneNumber ?? string.Empty,
            UserName = applicationUser.UserName ?? string.Empty,
        };
    }

    public static ApplicationUser ToApplicationUser(ApplicationUserAdminDto applicationUserAdminDto)
    {
        var applicationUser = new ApplicationUser
        {
            Email = applicationUserAdminDto.Email,
            Id = applicationUserAdminDto.Id,
            PhoneNumber = applicationUserAdminDto.PhoneNumber,
            UserName = applicationUserAdminDto.UserName,
        };

        applicationUser.ApplicationUserRoles = applicationUserAdminDto.ApplicationRoles.Select(x => new ApplicationUserRole
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
