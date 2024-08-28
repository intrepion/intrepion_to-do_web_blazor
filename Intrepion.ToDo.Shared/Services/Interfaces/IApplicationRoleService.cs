using Intrepion.ToDo.Shared.Entities;

namespace Intrepion.ToDo.Shared.Services.Interfaces;

public interface IApplicationRoleService
{
    Task<ApplicationRole> AddAsync(ApplicationRole applicationRole);
    Task<bool> DeleteAsync(string id);
    Task<ApplicationRole> EditAsync(string id, ApplicationRole applicationRole);
    Task<List<ApplicationRole>> GetAllAsync();
    Task<ApplicationRole> GetByIdAsync(string id);
}
