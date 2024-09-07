using Intrepion.ToDo.BusinessLogic.Entities;

namespace Intrepion.ToDo.BusinessLogic.Services;

public interface IApplicationUserAdminService
{
    Task<ApplicationUser?> AddAsync(string userName, ApplicationUser applicationUser);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ApplicationUser?> EditAsync(string userName, Guid id, ApplicationUser applicationUser);
    Task<List<ApplicationUser>?> GetAllAsync();
    Task<ApplicationUser?> GetByIdAsync(Guid id);
}
