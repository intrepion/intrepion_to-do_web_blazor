using AppNamePlaceholder.Shared.Data;
using AppNamePlaceholder.Shared.Entities;
using AppNamePlaceholder.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppNamePlaceholder.Shared.Services.Server;

public class ApplicationUserService(ApplicationDbContext applicationDbContext) : IApplicationUserService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<ApplicationUser> AddAsync(string userName, ApplicationUser applicationUser)
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

        if (string.IsNullOrWhiteSpace(applicationUser.Email))
        {
            throw new Exception("Email required.");
        }

        applicationUser.ApplicationUserUpdatedBy = user;
        applicationUser.EmailConfirmed = false;
        applicationUser.NormalizedEmail = applicationUser.Email?.ToUpper();
        applicationUser.NormalizedUserName = applicationUser.Email?.ToUpper();
        applicationUser.UserName = applicationUser.Email;

        _applicationDbContext.Users.Add(applicationUser);

        await _applicationDbContext.SaveChangesAsync();

        return applicationUser;
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

    public async Task<ApplicationUser> EditAsync(string userName, string id, ApplicationUser applicationUser)
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
        dbApplicationUser.Email = applicationUser.Email;
        dbApplicationUser.EmailConfirmed = false;
        dbApplicationUser.NormalizedEmail = applicationUser.Email?.ToUpper();
        dbApplicationUser.NormalizedUserName = applicationUser.Email?.ToUpper();
        dbApplicationUser.UserName = applicationUser.Email;

        if (dbApplicationUser.PhoneNumber != applicationUser.PhoneNumber)
        {
            dbApplicationUser.PhoneNumber = applicationUser.PhoneNumber;
            dbApplicationUser.PhoneNumberConfirmed = false;
        }

        await _applicationDbContext.SaveChangesAsync();

        return dbApplicationUser;
    }

    public async Task<List<ApplicationUser>> GetAllAsync()
    {
        var applicationUsers = await _applicationDbContext.Users.ToListAsync();

        return applicationUsers;
    }

    public async Task<ApplicationUser> GetByIdAsync(string id)
    {
        return await _applicationDbContext.Users.FindAsync(id);
    }
}
