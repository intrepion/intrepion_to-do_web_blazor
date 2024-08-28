using Intrepion.ToDo.Shared.Entities;

namespace Intrepion.ToDo.Shared.Services.Interfaces;

public interface IApplicationUserService
{
    Task<ApplicationUser> AddAsync(string userName, ApplicationUser applicationUser);
    Task<bool> DeleteAsync(string userName, string id);
    Task<ApplicationUser> EditAsync(string userName, string id, ApplicationUser applicationUser);
    Task<List<ApplicationUser>> GetAllAsync();
    Task<ApplicationUser> GetByIdAsync(string id);
}
