using System.ComponentModel.DataAnnotations;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Vms.Admin;

public class EntityNamePlaceholderAdminEditVm
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder

    public static EntityNamePlaceholderAdminEditVm FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto toDoItemAdminDto)
    {
        if (toDoItemAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditVm();
        }

        return new EntityNamePlaceholderAdminEditVm
        {
            Id = toDoItemAdminDto.Id,

            // DtoToModelPlaceholder
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditVm toDoItemAdminEditVm)
    {
        if (toDoItemAdminEditVm == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = toDoItemAdminEditVm.Id,

            // ModelToDtoPlaceholder
        };
    }
}
