using AppNamePlaceholder.Shared.Data;
using AppNamePlaceholder.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppNamePlaceholder.Shared.Services;

public class ApplicationRoleService(ApplicationDbContext applicationDbContext) : IApplicationRoleService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<ApplicationRole> AddAsync(ApplicationRole applicationRole)
    {
        _applicationDbContext.Roles.Add(applicationRole);
        await _applicationDbContext.SaveChangesAsync();

        return applicationRole;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var dbApplicationRole = await _applicationDbContext.Roles.FindAsync(id);

        if (dbApplicationRole == null)
        {
            return false;
        }

        _applicationDbContext.Remove(dbApplicationRole);
        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<ApplicationRole> EditAsync(Guid id, ApplicationRole applicationRole)
    {
        var dbApplicationRole = await _applicationDbContext.Roles.FindAsync(id);

        if (dbApplicationRole == null)
        {
            throw new Exception("ApplicationRole not found.");
        }

        dbApplicationRole.Name = applicationRole.Name;
        await _applicationDbContext.SaveChangesAsync();

        return dbApplicationRole;
    }

    public async Task<List<ApplicationRole>> GetAllAsync()
    {
        await Task.Delay(1000);

        var applicationRoles = await _applicationDbContext.Roles.ToListAsync();

        return applicationRoles;
    }

    public async Task<ApplicationRole> GetByIdAsync(Guid id)
    {
        return await _applicationDbContext.Roles.FindAsync(id);
    }
}
