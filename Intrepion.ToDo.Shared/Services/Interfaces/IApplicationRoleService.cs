using Intrepion.ToDo.Shared.Entities;

namespace Intrepion.ToDo.Shared.Services.Interfaces;

public interface IApplicationRoleService
{
    Task<ApplicationRole> AddAsync(string userName, ApplicationRole applicationRole);
    Task<bool> DeleteAsync(string userName, string id);
    Task<ApplicationRole> EditAsync(string userName, string id, ApplicationRole applicationRole);
    Task<List<ApplicationRole>> GetAllAsync();
    Task<ApplicationRole> GetByIdAsync(string id);
}
