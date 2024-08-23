using Intrepion.ToDo.Shared.Data;
using Intrepion.ToDo.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.ToDo.Shared.Services;

public class ApplicationRoleService : IApplicationRoleService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ApplicationRoleService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<ApplicationRole>> GetAllAsync()
    {
        var objectNamePlaceholders = await _applicationDbContext.DatabaseNamePlaceholders.ToListAsync();

        return objectNamePlaceholders;
    }
}
