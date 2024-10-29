using System.ComponentModel.DataAnnotations;
using Intrepion.ToDo.BusinessLogic.Entities.Dtos.Admin;

namespace Intrepion.ToDo.BusinessLogic.Entities.Vms.Admin;

public class ApplicationRoleAdminEditVm
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;

    public static ApplicationRoleAdminEditVm FromApplicationRoleAdminDto(ApplicationRoleAdminDto? applicationRoleAdminDto)
    {
        if (applicationRoleAdminDto == null)
        {
            return new ApplicationRoleAdminEditVm();
        }

        return new ApplicationRoleAdminEditVm
        {
            Id = applicationRoleAdminDto.Id,
            Name = applicationRoleAdminDto.Name,
        };
    }

    public static ApplicationRoleAdminDto ToApplicationRoleAdminDto(ApplicationRoleAdminEditVm? applicationRoleAdminEditVm)
    {
        if (applicationRoleAdminEditVm == null)
        {
            return new ApplicationRoleAdminDto();
        }

        return new ApplicationRoleAdminDto
        {
            Id = applicationRoleAdminEditVm.Id,
            Name = applicationRoleAdminEditVm.Name,
        };
    }
}
