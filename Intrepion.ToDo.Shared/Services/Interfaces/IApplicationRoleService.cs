﻿using AppNamePlaceholder.Shared.Entities;

namespace AppNamePlaceholder.Shared.Services.Interfaces;

public interface IApplicationRoleService
{
    Task<ApplicationRole> AddAsync(ApplicationRole applicationRole);
    Task<bool> DeleteAsync(string id);
    Task<ApplicationRole> EditAsync(string id, ApplicationRole applicationRole);
    Task<List<ApplicationRole>> GetAllAsync();
    Task<ApplicationRole> GetByIdAsync(string id);
}
