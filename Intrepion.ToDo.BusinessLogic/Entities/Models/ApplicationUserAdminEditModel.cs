using Intrepion.ToDo.BusinessLogic.Entities.Dtos;

namespace Intrepion.ToDo.BusinessLogic.Entities.Models;

public class ApplicationUserAdminEditModel
{
    public List<ApplicationRoleAdminEditModel> ApplicationRoles { get; set; } = [];
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public static ApplicationUserAdminEditModel FromApplicationUserAdminDto(ApplicationUserAdminDto? applicationUserAdminDto)
    {
        if (applicationUserAdminDto == null)
        {
            return new ApplicationUserAdminEditModel();
        }

        var applicationUserAdminEditModel = new ApplicationUserAdminEditModel
        {
            ApplicationRoles = applicationUserAdminDto.ApplicationRoles.Select(x => new ApplicationRoleAdminEditModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList(),

            Email = applicationUserAdminDto.Email,
            Id = applicationUserAdminDto.Id,
            PhoneNumber = applicationUserAdminDto.PhoneNumber,
            UserName = applicationUserAdminDto.UserName,
        };

        return applicationUserAdminEditModel;
    }

    public static ApplicationUserAdminDto ToApplicationUserAdminDto(ApplicationUserAdminEditModel? applicationUserAdminEditModel)
    {
        if (applicationUserAdminEditModel == null)
        {
            return new ApplicationUserAdminDto();
        }

        var applicationUser = new ApplicationUserAdminDto
        {
            ApplicationRoles = applicationUserAdminEditModel.ApplicationRoles.Select(x => new ApplicationRoleAdminDto
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
