using Intrepion.ToDo.BusinessLogic.Data;
using Intrepion.ToDo.BusinessLogic.Entities;
using Intrepion.ToDo.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.ToDo.BusinessLogic.Services.Server;

public class ApplicationUserAdminService(ApplicationDbContext applicationDbContext) : IApplicationUserAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<ApplicationUserAdminDto?> AddAsync(ApplicationUserAdminDto applicationUserAdminDto)
    {
        if (string.IsNullOrWhiteSpace(applicationUserAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => applicationUserAdminDto.ApplicationUserName.ToUpperInvariant().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        if (string.IsNullOrWhiteSpace(applicationUserAdminDto.Email))
        {
            throw new Exception("Email required.");
        }

        if (string.IsNullOrWhiteSpace(applicationUserAdminDto.UserName))
        {
            throw new Exception("UserName required.");
        }

        var applicationUser = new ApplicationUser
        {
            ApplicationUserUpdatedBy = user,
            Email = applicationUserAdminDto.Email,
            NormalizedEmail = applicationUserAdminDto.Email?.ToUpperInvariant(),
            PhoneNumber = applicationUserAdminDto.PhoneNumber,
            UserName = applicationUserAdminDto.UserName,
            NormalizedUserName = applicationUserAdminDto.UserName?.ToUpperInvariant()
        };

        var databaseApplicationUser = (await _applicationDbContext.Users.AddAsync(applicationUser)).Entity;
        var databaseApplicationUserAdminDto = ApplicationUserAdminDto.FromApplicationUser(databaseApplicationUser);
        var applicationRoleIds = applicationUserAdminDto.ApplicationRoles.Select(x => x.Id);
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

            databaseApplicationUserAdminDto.ApplicationRoles.Add(ApplicationRoleAdminDto.FromApplicationRole(applicationRole));
        }

        await _applicationDbContext.SaveChangesAsync();

        return databaseApplicationUserAdminDto;
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

    public async Task<ApplicationUserAdminDto?> EditAsync(ApplicationUserAdminDto applicationUserAdminDto)
    {
        if (string.IsNullOrWhiteSpace(applicationUserAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => applicationUserAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseApplicationUser = await _applicationDbContext.Users.FindAsync(applicationUserAdminDto.Id);

        if (databaseApplicationUser == null)
        {
            throw new Exception("Application User not found.");
        }

        if (string.IsNullOrWhiteSpace(applicationUserAdminDto.Email))
        {
            throw new Exception("Email required.");
        }

        if (string.IsNullOrWhiteSpace(applicationUserAdminDto.UserName))
        {
            throw new Exception("UserName required.");
        }

        databaseApplicationUser.ApplicationUserUpdatedBy = user;
        databaseApplicationUser.Email = applicationUserAdminDto.Email;
        databaseApplicationUser.NormalizedEmail = applicationUserAdminDto.Email?.ToUpper();
        databaseApplicationUser.PhoneNumber = applicationUserAdminDto.PhoneNumber;
        databaseApplicationUser.UserName = applicationUserAdminDto.UserName;
        databaseApplicationUser.NormalizedUserName = applicationUserAdminDto.UserName?.ToUpper();

        var applicationRoleIds = applicationUserAdminDto.ApplicationRoles.Select(x => x.Id);
        var deletedRoles = databaseApplicationUser.ApplicationUserRoles.Where(x => !(x.ApplicationRole != null && applicationRoleIds.Contains(x.ApplicationRole.Id)));
        applicationUserAdminDto.ApplicationRoles = applicationUserAdminDto.ApplicationRoles.Where(x => !applicationRoleIds.Contains(x.Id)).ToList();
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
            applicationUserAdminDto.ApplicationRoles.Add(ApplicationRoleAdminDto.FromApplicationRole(additionalApplicationRole));
        }

        await _applicationDbContext.SaveChangesAsync();

        return applicationUserAdminDto;
    }

    public async Task<List<ApplicationUserAdminDto>?> GetAllAsync(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var applicationUser = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpperInvariant().Equals(x.NormalizedUserName));

        if (applicationUser == null)
        {
            throw new Exception("Authentication required.");
        }

        var result = await _applicationDbContext.Users.Include(x => x.ApplicationUserRoles).ThenInclude(x => x.ApplicationRole).ToListAsync();

        if (result == null)
        {
            return null;
        }

        var applicationUserAdminDto = new ApplicationUserAdminDto();

        return result.Select(x => ApplicationUserAdminDto.FromApplicationUser(x)).ToList();
    }

    public async Task<ApplicationUserAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var applicationUser = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpperInvariant().Equals(x.NormalizedUserName));

        if (applicationUser == null)
        {
            throw new Exception("Authentication required.");
        }

        var result = await _applicationDbContext.Users.Include(x => x.ApplicationUserRoles).ThenInclude(x => x.ApplicationRole).Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

        if (result == null)
        {
            return null;
        }

        return ApplicationUserAdminDto.FromApplicationUser(result);
    }
}
