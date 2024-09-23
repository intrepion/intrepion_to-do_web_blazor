using Intrepion.ToDo.BusinessLogic.Entities;
using Intrepion.ToDo.BusinessLogic.Entities.Dtos;

namespace Intrepion.ToDo.BusinessLogic.Services;

public interface IApplicationRoleAdminService
{
    Task<ApplicationRoleAdminDto?> AddAsync(ApplicationRoleAdminDto applicationRoleAdminDto);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ApplicationRoleAdminDto?> EditAsync(ApplicationRoleAdminDto applicationRoleAdminDto);
    Task<List<ApplicationRole>?> GetAllAsync(string userName);
    Task<ApplicationRoleAdminDto?> GetByIdAsync(string userName, Guid id);
}
