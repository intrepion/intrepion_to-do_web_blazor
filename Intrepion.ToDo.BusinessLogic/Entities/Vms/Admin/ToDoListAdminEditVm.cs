using System.ComponentModel.DataAnnotations;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Vms.Admin;

public class EntityNamePlaceholderAdminEditVm
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder

    public static EntityNamePlaceholderAdminEditVm FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto EntityLowercaseNamePlaceholderAdminDto)
    {
        if (EntityLowercaseNamePlaceholderAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditVm();
        }

        return new EntityNamePlaceholderAdminEditVm
        {
            Id = EntityLowercaseNamePlaceholderAdminDto.Id,

            // DtoToModelPlaceholder
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditVm EntityLowercaseNamePlaceholderAdminEditVm)
    {
        if (EntityLowercaseNamePlaceholderAdminEditVm == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = EntityLowercaseNamePlaceholderAdminEditVm.Id,

            // ModelToDtoPlaceholder
        };
    }
}
