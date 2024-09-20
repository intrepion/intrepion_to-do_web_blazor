using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class ApplicationUserAdminService(ApplicationDbContext applicationDbContext) : IApplicationUserAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<ApplicationUserAdminDataTransferObject?> AddAsync(string userName, ApplicationUserAdminDataTransferObject applicationUserAdminDataTransferObject)
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

        if (string.IsNullOrWhiteSpace(applicationUserAdminDataTransferObject.Email))
        {
            throw new Exception("Email required.");
        }

        if (string.IsNullOrWhiteSpace(applicationUserAdminDataTransferObject.UserName))
        {
            throw new Exception("UserName required.");
        }

        var applicationUser = new ApplicationUser
        {
            ApplicationUserUpdatedBy = user,
            Email = applicationUserAdminDataTransferObject.Email,
            NormalizedEmail = applicationUserAdminDataTransferObject.Email?.ToUpperInvariant(),
            PhoneNumber = applicationUserAdminDataTransferObject.PhoneNumber,
            UserName = applicationUserAdminDataTransferObject.UserName,
            NormalizedUserName = applicationUserAdminDataTransferObject.UserName?.ToUpperInvariant()
        };

        var databaseApplicationUser = (await _applicationDbContext.Users.AddAsync(applicationUser)).Entity;
        var databaseApplicationUserAdminDataTransferObject = ApplicationUserAdminDataTransferObject.FromApplicationUser(databaseApplicationUser);
        var applicationRoleIds = applicationUserAdminDataTransferObject.ApplicationRoles.Select(x => x.Id);
        var applicationRoles = await _applicationDbContext.Roles.Where(x => applicationRoleIds.Contains(x.Id)).ToListAsync();

        foreach (var applicationRole in applicationRoles)
        {
            var applicationUserRole = new ApplicationUserRole
            {
                ApplicationRole = applicationRole,
                ApplicationUser = databaseApplicationUser,
                ApplicationUserUpdatedBy = user,
            };

            await _applicationDbContext.UserRoles.AddAsync(applicationUserRole);

            databaseApplicationUserAdminDataTransferObject.ApplicationRoles.Add(ApplicationRoleAdminDataTransferObject.FromApplicationRole(applicationRole));
        }

        await _applicationDbContext.SaveChangesAsync();

        return databaseApplicationUserAdminDataTransferObject;
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseApplicationUser = await _applicationDbContext.Users.FindAsync(id);

        if (databaseApplicationUser == null)
        {
            return false;
        }

        databaseApplicationUser.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseApplicationUser);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<ApplicationUserAdminDataTransferObject?> EditAsync(string userName, Guid id, ApplicationUserAdminDataTransferObject applicationUserAdminDataTransferObject)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseApplicationUser = await _applicationDbContext.Users.FindAsync(id);

        if (databaseApplicationUser == null)
        {
            throw new Exception("Application User not found.");
        }

        if (string.IsNullOrWhiteSpace(applicationUserAdminDataTransferObject.Email))
        {
            throw new Exception("Email required.");
        }

        if (string.IsNullOrWhiteSpace(applicationUserAdminDataTransferObject.UserName))
        {
            throw new Exception("UserName required.");
        }

        databaseApplicationUser.ApplicationUserUpdatedBy = user;
        databaseApplicationUser.Email = applicationUserAdminDataTransferObject.Email;
        databaseApplicationUser.NormalizedEmail = applicationUserAdminDataTransferObject.Email?.ToUpper();
        databaseApplicationUser.PhoneNumber = applicationUserAdminDataTransferObject.PhoneNumber;
        databaseApplicationUser.UserName = applicationUserAdminDataTransferObject.UserName;
        databaseApplicationUser.NormalizedUserName = applicationUserAdminDataTransferObject.UserName?.ToUpper();

        var applicationRoleIds = applicationUserAdminDataTransferObject.ApplicationRoles.Select(x => x.Id);
        var deletedRoles = databaseApplicationUser.ApplicationUserRoles.Where(x => !(x.ApplicationRole != null && applicationRoleIds.Contains(x.ApplicationRole.Id)));
        applicationUserAdminDataTransferObject.ApplicationRoles = applicationUserAdminDataTransferObject.ApplicationRoles.Where(x => !applicationRoleIds.Contains(x.Id)).ToList();
        var additionalApplicationRoleIds = applicationRoleIds.Where(x => !databaseApplicationUser.ApplicationUserRoles.Select(x => x.RoleId).Contains(x)).ToList();
        var additionalApplicationRoles = await _applicationDbContext.Roles.Where(x => additionalApplicationRoleIds.Contains(x.Id)).ToListAsync();

        foreach (var deletedRole in deletedRoles)
        {
            _applicationDbContext.Remove(deletedRole);
        }

        foreach (var additionalApplicationRole in additionalApplicationRoles)
        {
            var applicationUserRole = new ApplicationUserRole
            {
                ApplicationRole = additionalApplicationRole,
                ApplicationUser = databaseApplicationUser,
                ApplicationUserUpdatedBy = user,
            };

            await _applicationDbContext.UserRoles.AddAsync(applicationUserRole);
            applicationUserAdminDataTransferObject.ApplicationRoles.Add(ApplicationRoleAdminDataTransferObject.FromApplicationRole(additionalApplicationRole));
        }

        await _applicationDbContext.SaveChangesAsync();

        return applicationUserAdminDataTransferObject;
    }

    public async Task<List<ApplicationUserAdminDataTransferObject>?> GetAllAsync()
    {
        var result = await _applicationDbContext.Users.Include(x => x.ApplicationUserRoles).ThenInclude(x => x.ApplicationRole).ToListAsync();

        if (result == null)
        {
            return null;
        }

        var applicationUserAdminDataTransferObject = new ApplicationUserAdminDataTransferObject();

        return result.Select(x => ApplicationUserAdminDataTransferObject.FromApplicationUser(x)).ToList();
    }

    public async Task<ApplicationUserAdminDataTransferObject?> GetByIdAsync(Guid id)
    {
        var result = await _applicationDbContext.Users.Include(x => x.ApplicationUserRoles).ThenInclude(x => x.ApplicationRole).Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

        if (result == null)
        {
            return null;
        }

        return ApplicationUserAdminDataTransferObject.FromApplicationUser(result);
    }
}
