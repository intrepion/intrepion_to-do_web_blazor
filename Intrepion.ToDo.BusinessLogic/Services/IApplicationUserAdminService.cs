using Intrepion.ToDo.BusinessLogic.Entities;
using Intrepion.ToDo.BusinessLogic.Entities.Dtos;

namespace Intrepion.ToDo.BusinessLogic.Services;

public interface IApplicationUserAdminService
{
    Task<ApplicationUserAdminDto?> AddAsync(ApplicationUserAdminDto applicationUserAdminDto);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ApplicationUserAdminDto?> EditAsync(ApplicationUserAdminDto applicationUserAdminDto);
    Task<List<ApplicationUser>?> GetAllAsync(string userName);
    Task<ApplicationUserAdminDto?> GetByIdAsync(string userName, Guid id);
}
