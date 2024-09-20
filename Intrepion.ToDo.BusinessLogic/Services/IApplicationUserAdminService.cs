﻿using Intrepion.ToDo.BusinessLogic.Entities.DataTransferObjects;

namespace Intrepion.ToDo.BusinessLogic.Services;

public interface IApplicationUserAdminService
{
    Task<ApplicationUserAdminDataTransferObject?> AddAsync(string userName, ApplicationUserAdminDataTransferObject applicationUserAdminDataTransferObject);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ApplicationUserAdminDataTransferObject?> EditAsync(string userName, Guid id, ApplicationUserAdminDataTransferObject applicationUserAdminDataTransferObject);
    Task<List<ApplicationUserAdminDataTransferObject>?> GetAllAsync();
    Task<ApplicationUserAdminDataTransferObject?> GetByIdAsync(Guid id);
}
