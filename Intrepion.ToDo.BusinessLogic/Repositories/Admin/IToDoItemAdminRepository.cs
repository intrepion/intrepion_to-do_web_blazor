﻿using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin;

public interface IEntityNamePlaceholderAdminRepository
{
    Task<EntityNamePlaceholderAdminDto?> AddAsync(EntityNamePlaceholderAdminDto toDoItem);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<EntityNamePlaceholderAdminDto?> EditAsync(EntityNamePlaceholderAdminDto toDoItem);
    Task<List<EntityNamePlaceholderAdminDto>?> GetAllAsync(string userName);
    Task<EntityNamePlaceholderAdminDto?> GetByIdAsync(string userName, Guid id);
}
