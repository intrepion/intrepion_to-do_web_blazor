using Intrepion.ToDo.Shared.Data;
using Intrepion.ToDo.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.ToDo.Shared.Services;

public class ApplicationRoleService(ApplicationDbContext applicationDbContext) : IApplicationRoleService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public async Task<List<ApplicationRole>> GetAllAsync()
    {
        var applicationRoles = await _applicationDbContext.Roles.ToListAsync();

        return applicationRoles;
    }
}
