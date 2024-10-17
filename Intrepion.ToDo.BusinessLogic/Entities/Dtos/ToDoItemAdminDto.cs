﻿namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class EntityNamePlaceholderAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder

    public static EntityNamePlaceholderAdminDto FromEntityNamePlaceholder(EntityNamePlaceholder? EntityLowercaseNamePlaceholder)
    {
        if (EntityLowercaseNamePlaceholder == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = EntityLowercaseNamePlaceholder.Id,

            // EntityToDtoPlaceholder
        };
    }

    public static EntityNamePlaceholder ToEntityNamePlaceholder(ApplicationUser applicationUser, EntityNamePlaceholderAdminDto EntityLowercaseNamePlaceholderAdminDto)
    {
        return new EntityNamePlaceholder
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = EntityLowercaseNamePlaceholderAdminDto.Id,

            // DtoToEntityPropertyPlaceholder
        };
    }
}
