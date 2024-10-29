using System.ComponentModel.DataAnnotations;
using Intrepion.ToDo.BusinessLogic.Entities.Dtos.Admin;

namespace Intrepion.ToDo.BusinessLogic.Entities.Vms.Admin;

public class ApplicationUserAdminEditVm
{
    public List<ApplicationRole> ApplicationRoles { get; set; } = [];
    public Guid Id { get; set; }
    [Required]
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    [Required]
    public string UserName { get; set; } = string.Empty;

    public static ApplicationUserAdminEditVm FromApplicationUserAdminDto(ApplicationUserAdminDto applicationUserAdminDto)
    {
        if (applicationUserAdminDto == null)
        {
            return new ApplicationUserAdminEditVm();
        }

        var applicationUserAdminEditVm = new ApplicationUserAdminEditVm
        {
            ApplicationRoles = applicationUserAdminDto.ApplicationRoles,
            Email = applicationUserAdminDto.Email,
            Id = applicationUserAdminDto.Id,
            PhoneNumber = applicationUserAdminDto.PhoneNumber,
            UserName = applicationUserAdminDto.UserName,
        };

        return applicationUserAdminEditVm;
    }

    public static ApplicationUserAdminDto ToApplicationUserAdminDto(ApplicationUserAdminEditVm? applicationUserAdminEditVm)
    {
        if (applicationUserAdminEditVm == null)
        {
            return new ApplicationUserAdminDto();
        }

        var applicationUserAdminDto = new ApplicationUserAdminDto
        {
            ApplicationRoles = applicationUserAdminEditVm.ApplicationRoles,
            Email = applicationUserAdminEditVm.Email,
            Id = applicationUserAdminEditVm.Id,
            PhoneNumber = applicationUserAdminEditVm.PhoneNumber,
            UserName = applicationUserAdminEditVm.UserName,
        };

        return applicationUserAdminDto;
    }
}
