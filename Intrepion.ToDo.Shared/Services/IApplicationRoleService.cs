using Intrepion.ToDo.Shared.Entities;

namespace Intrepion.ToDo.Shared.Services;

public interface IApplicationRoleService
{
    Task<ApplicationRole> AddAsync(ApplicationRole applicationRole);
    Task<bool> DeleteAsync(Guid id);
    Task<ApplicationRole> EditAsync(Guid id, ApplicationRole applicationRole);
    Task<List<ApplicationRole>> GetAllAsync();
    Task<ApplicationRole> GetByIdAsync(Guid id);
}
