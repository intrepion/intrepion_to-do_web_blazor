using Intrepion.ToDo.Shared.Entities;

namespace Intrepion.ToDo.Shared.Services.Interfaces;

public interface IApplicationUserService
{
    Task<ApplicationUser> AddAsync(ApplicationUser applicationUser);
    Task<bool> DeleteAsync(string id);
    Task<ApplicationUser> EditAsync(string id, ApplicationUser applicationUser);
    Task<List<ApplicationUser>> GetAllAsync();
    Task<ApplicationUser> GetByIdAsync(string id);
}
