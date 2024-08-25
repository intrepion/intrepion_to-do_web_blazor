using Intrepion.ToDo.Shared.Entities;

namespace Intrepion.ToDo.Shared.Services;

public interface IApplicationRoleService
{
    Task<List<ApplicationRole>> GetAllAsync();
}
