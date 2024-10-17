using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class EntityNamePlaceholderAdminEditModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder

    public static EntityNamePlaceholderAdminEditModel FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto EntityLowercaseNamePlaceholderAdminDto)
    {
        if (EntityLowercaseNamePlaceholderAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditModel();
        }

        return new EntityNamePlaceholderAdminEditModel
        {
            Id = EntityLowercaseNamePlaceholderAdminDto.Id,

            // DtoToModelPlaceholder
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditModel EntityLowercaseNamePlaceholderAdminEditModel)
    {
        if (EntityLowercaseNamePlaceholderAdminEditModel == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = EntityLowercaseNamePlaceholderAdminEditModel.Id,

            // ModelToDtoPlaceholder
        };
    }
}
