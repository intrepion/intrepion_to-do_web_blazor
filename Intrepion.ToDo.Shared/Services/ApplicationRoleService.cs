using AppNamePlaceholder.Shared.Data;
using AppNamePlaceholder.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppNamePlaceholder.Shared.Services;

public class ApplicationRoleService(ApplicationDbContext applicationDbContext) : IApplicationRoleService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public async Task<List<ApplicationRole>> GetAllAsync()
    {
        var applicationRoles = await _applicationDbContext.Roles.ToListAsync();

        return applicationRoles;
    }
}
