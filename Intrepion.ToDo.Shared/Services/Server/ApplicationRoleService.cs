using AppNamePlaceholder.Shared.Data;
using AppNamePlaceholder.Shared.Entities;
using AppNamePlaceholder.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppNamePlaceholder.Shared.Services.Server;

public class ApplicationRoleService(ApplicationDbContext applicationDbContext) : IApplicationRoleService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<ApplicationRole> AddAsync(ApplicationRole applicationRole)
    {
        if (string.IsNullOrWhiteSpace(applicationRole.Name))
        {
            throw new Exception("Name required.");
        }

        applicationRole.NormalizedName = applicationRole.Name?.ToUpper();

        _applicationDbContext.Roles.Add(applicationRole);

        await _applicationDbContext.SaveChangesAsync();

        return applicationRole;
    }

    public async Task<bool> DeleteAsync(string id)
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

    public async Task<ApplicationRole> EditAsync(string id, ApplicationRole applicationRole)
    {
        var dbApplicationRole = await _applicationDbContext.Roles.FindAsync(id);

        if (dbApplicationRole == null)
        {
            throw new Exception("Application role not found.");
        }

        if (string.IsNullOrWhiteSpace(applicationRole.Name))
        {
            throw new Exception("Name required.");
        }

        dbApplicationRole.Name = applicationRole.Name;
        dbApplicationRole.NormalizedName = applicationRole.Name?.ToUpper();

        await _applicationDbContext.SaveChangesAsync();

        return dbApplicationRole;
    }

    public async Task<List<ApplicationRole>> GetAllAsync()
    {
        var applicationRoles = await _applicationDbContext.Roles.ToListAsync();

        return applicationRoles;
    }

    public async Task<ApplicationRole> GetByIdAsync(string id)
    {
        return await _applicationDbContext.Roles.FindAsync(id);
    }
}
