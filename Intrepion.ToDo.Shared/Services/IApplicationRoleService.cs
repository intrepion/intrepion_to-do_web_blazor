using AppNamePlaceholder.Shared.Entities;

namespace AppNamePlaceholder.Shared.Services;

public interface IApplicationRoleService
{
    Task<List<ApplicationRole>> GetAllAsync();
}
