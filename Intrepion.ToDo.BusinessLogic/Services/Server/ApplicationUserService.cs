using Intrepion.ToDo.BusinessLogic.Data;
using Intrepion.ToDo.BusinessLogic.Entities;
using Intrepion.ToDo.BusinessLogic.Entities.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.ToDo.BusinessLogic.Services.Server;

public class ApplicationUserService(ApplicationDbContext applicationDbContext) : IApplicationUserService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<AdminApplicationUserEditDataTransferObject?> AddAsync(string userName, AdminApplicationUserEditDataTransferObject adminApplicationUserEditDataTransferObject)
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

        if (string.IsNullOrWhiteSpace(adminApplicationUserEditDataTransferObject.Email))
        {
            throw new Exception("Email required.");
        }

        var applicationUser = new ApplicationUser
        {
            ApplicationUserUpdatedBy = user,
            Email = adminApplicationUserEditDataTransferObject.Email,
            EmailConfirmed = false,
            NormalizedEmail = adminApplicationUserEditDataTransferObject.Email?.ToUpper(),
            NormalizedUserName = adminApplicationUserEditDataTransferObject.UserName?.ToUpper(),
            UserName = adminApplicationUserEditDataTransferObject.UserName,
        };

        _applicationDbContext.Users.Add(applicationUser);

        await _applicationDbContext.SaveChangesAsync();

        return adminApplicationUserEditDataTransferObject;
    }

    public async Task<bool> DeleteAsync(string userName, string id)
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

        var dbApplicationUser = await _applicationDbContext.Users.FindAsync(id);

        if (dbApplicationUser == null)
        {
            return false;
        }

        dbApplicationUser.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(dbApplicationUser);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<AdminApplicationUserEditDataTransferObject?> EditAsync(string userName, string id, AdminApplicationUserEditDataTransferObject adminApplicationUserEditDataTransferObject)
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

        var dbApplicationUser = await _applicationDbContext.Users.FindAsync(id);

        if (dbApplicationUser == null)
        {
            throw new Exception("Application user not found.");
        }

        if (string.IsNullOrWhiteSpace(dbApplicationUser.Email))
        {
            throw new Exception("Email required.");
        }

        dbApplicationUser.ApplicationUserUpdatedBy = user;
        dbApplicationUser.Email = adminApplicationUserEditDataTransferObject.Email;
        dbApplicationUser.EmailConfirmed = false;
        dbApplicationUser.NormalizedEmail = adminApplicationUserEditDataTransferObject.Email?.ToUpper();
        dbApplicationUser.NormalizedUserName = adminApplicationUserEditDataTransferObject.UserName?.ToUpper();
        dbApplicationUser.UserName = adminApplicationUserEditDataTransferObject.UserName;

        if (dbApplicationUser.PhoneNumber != adminApplicationUserEditDataTransferObject.PhoneNumber)
        {
            dbApplicationUser.PhoneNumber = adminApplicationUserEditDataTransferObject.PhoneNumber;
            dbApplicationUser.PhoneNumberConfirmed = false;
        }

        await _applicationDbContext.SaveChangesAsync();

        return adminApplicationUserEditDataTransferObject;
    }

    public async Task<List<AdminApplicationUserListItemDataTransferObject>?> GetAllAsync()
    {
        var applicationRoles = await _applicationDbContext.Roles.ToListAsync();
        var applicationUsers = await _applicationDbContext.Users.ToListAsync();
        var applicationUserRoles = await _applicationDbContext.UserRoles.ToListAsync();
        var adminApplicationUserListItemDataTransferObjects = applicationUsers.Select(x => new AdminApplicationUserListItemDataTransferObject
        {
            ApplicationRoles = applicationUserRoles
                .Where(y => y.UserId == x.Id)
                .Select(y => applicationRoles.Single(z => z.Id == y.RoleId))
                .ToList(),
            Email = x.Email ?? string.Empty,
            Id = new Guid(x.Id),
            PhoneNumber = x.PhoneNumber ?? string.Empty,
            UserName = x.UserName ?? string.Empty,
        }).ToList();

        return adminApplicationUserListItemDataTransferObjects;
    }

    public async Task<AdminApplicationUserEditDataTransferObject?> GetByIdAsync(string id)
    {
        var applicationUser = await _applicationDbContext.Users.FindAsync(id);
        if (applicationUser == null)
        {
            return null;
        }

        var applicationRoles = await _applicationDbContext.Roles.ToListAsync();
        var applicationUserRoles = await _applicationDbContext.UserRoles.ToListAsync();
        var adminApplicationUserEditDataTransferObject = new AdminApplicationUserEditDataTransferObject
        {
            ApplicationRoles = applicationUserRoles
                .Where(x => x.UserId == id)
                .Select(x => applicationRoles.Single(y => y.Id == x.RoleId))
                .ToList(),
            Email = applicationUser.Email ?? string.Empty,
            Id = new Guid(applicationUser.Id),
            PhoneNumber = applicationUser.PhoneNumber ?? string.Empty,
            UserName = applicationUser.UserName ?? string.Empty,
        };

        return adminApplicationUserEditDataTransferObject;
    }
}
