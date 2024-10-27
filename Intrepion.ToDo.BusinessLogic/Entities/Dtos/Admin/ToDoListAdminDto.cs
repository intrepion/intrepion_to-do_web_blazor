﻿namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

public class EntityNamePlaceholderAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder

    public static EntityNamePlaceholderAdminDto FromEntityNamePlaceholder(EntityNamePlaceholder? toDoList)
    {
        if (toDoList == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = toDoList.Id,

            // EntityToDtoPlaceholder
        };
    }

    public static EntityNamePlaceholder ToEntityNamePlaceholder(ApplicationUser? applicationUser, EntityNamePlaceholderAdminDto? toDoListAdminDto)
    {
        return new EntityNamePlaceholder
        {
            ApplicationUserUpdatedBy = applicationUser ?? new ApplicationUser(),
            Id = toDoListAdminDto?.Id ?? new Guid(),

            // DtoToEntityPropertyPlaceholder
        };
    }
}
