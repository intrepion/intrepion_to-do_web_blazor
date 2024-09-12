using Microsoft.EntityFrameworkCore;
using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class ApplicationRoleAdminService(ApplicationDbContext applicationDbContext) : IApplicationRoleAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<ApplicationRoleAdminDataTransferObject?> AddAsync(string userName, ApplicationRoleAdminDataTransferObject applicationRoleAdminDataTransferObject)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpperInvariant().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        if (string.IsNullOrWhiteSpace(applicationRoleAdminDataTransferObject.Name))
        {
            throw new Exception("Name required.");
        }

        var databaseApplicationRole = new ApplicationRole
        {
            ApplicationUserUpdatedBy = user,
            Name = applicationRoleAdminDataTransferObject.Name,
            NormalizedName = applicationRoleAdminDataTransferObject.Name?.ToUpperInvariant()
        };

        var result = await _applicationDbContext.Roles.AddAsync(databaseApplicationRole);

        var newDatabaseApplicationRoleAdminDataTransferObject = ApplicationRoleAdminDataTransferObject.FromApplicationRole(result.Entity);

        await _applicationDbContext.SaveChangesAsync();

        return newDatabaseApplicationRoleAdminDataTransferObject;
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpperInvariant().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseApplicationRole = await _applicationDbContext.Roles.FindAsync(id);

        if (databaseApplicationRole == null)
        {
            return false;
        }

        databaseApplicationRole.ApplicationUserUpdatedBy = user;

        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseApplicationRole);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<ApplicationRoleAdminDataTransferObject?> EditAsync(string userName, Guid id, ApplicationRoleAdminDataTransferObject applicationRoleAdminDataTransferObject)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpperInvariant().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseApplicationRole = await _applicationDbContext.Roles.FindAsync(id);

        if (databaseApplicationRole == null)
        {
            throw new Exception("Application role not found.");
        }

        if (string.IsNullOrWhiteSpace(applicationRoleAdminDataTransferObject.Name))
        {
            throw new Exception("Name required.");
        }

        databaseApplicationRole.ApplicationUserUpdatedBy = user;
        databaseApplicationRole.Name = applicationRoleAdminDataTransferObject.Name;
        databaseApplicationRole.NormalizedName = applicationRoleAdminDataTransferObject.Name?.ToUpperInvariant();

        await _applicationDbContext.SaveChangesAsync();

        return applicationRoleAdminDataTransferObject;
    }

    public async Task<List<ApplicationRoleAdminDataTransferObject>?> GetAllAsync()
    {
        var result = await _applicationDbContext.Roles.ToListAsync();

        if (result == null)
        {
            return null;
        }

        var applicationRoleAdminDataTransferObject = new ApplicationRoleAdminDataTransferObject();

        return result.Select(x => ApplicationRoleAdminDataTransferObject.FromApplicationRole(x)).ToList();
    }

    public async Task<ApplicationRoleAdminDataTransferObject?> GetByIdAsync(Guid id)
    {
        var result = await _applicationDbContext.Roles.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return ApplicationRoleAdminDataTransferObject.FromApplicationRole(result);
    }
}
