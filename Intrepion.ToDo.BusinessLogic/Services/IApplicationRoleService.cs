﻿using Intrepion.ToDo.BusinessLogic.Entities;

namespace Intrepion.ToDo.BusinessLogic.Services;

public interface IApplicationRoleService
{
    Task<ApplicationRole> AddAsync(string userName, ApplicationRole applicationRole);
    Task<bool> DeleteAsync(string userName, string id);
    Task<ApplicationRole> EditAsync(string userName, string id, ApplicationRole applicationRole);
    Task<List<ApplicationRole>> GetAllAsync();
    Task<ApplicationRole> GetByIdAsync(string id);
}
