using AppNamePlaceholder.BusinessLogic.Entities;

namespace AppNamePlaceholder.BusinessLogic.Services;

public interface IAdminApplicationRoleService
{
    Task<ApplicationRole?> AddAsync(string userName, ApplicationRole applicationRole);
    Task<bool> DeleteAsync(string userName, string id);
    Task<ApplicationRole?> EditAsync(string userName, string id, ApplicationRole applicationRole);
    Task<List<ApplicationRole>?> GetAllAsync();
    Task<ApplicationRole?> GetByIdAsync(string id);
}
