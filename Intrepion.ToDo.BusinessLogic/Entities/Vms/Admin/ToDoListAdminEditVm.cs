using System.ComponentModel.DataAnnotations;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Vms.Admin;

public class EntityNamePlaceholderAdminEditVm
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder

    public static EntityNamePlaceholderAdminEditVm FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto toDoListAdminDto)
    {
        if (toDoListAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditVm();
        }

        return new EntityNamePlaceholderAdminEditVm
        {
            Id = toDoListAdminDto.Id,

            // DtoToModelPlaceholder
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditVm toDoListAdminEditVm)
    {
        if (toDoListAdminEditVm == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = toDoListAdminEditVm.Id,

            // ModelToDtoPlaceholder
        };
    }
}
