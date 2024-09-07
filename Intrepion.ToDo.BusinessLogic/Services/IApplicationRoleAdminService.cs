using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface IApplicationRoleAdminService
{
    Task<ApplicationRole?> AddAsync(string userName, ApplicationRole applicationRole);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ApplicationRole?> EditAsync(string userName, Guid id, ApplicationRole applicationRole);
    Task<List<ApplicationRole>?> GetAllAsync();
    Task<ApplicationRole?> GetByIdAsync(Guid id);
}
