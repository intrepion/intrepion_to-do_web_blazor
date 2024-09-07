using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class ApplicationUserAdminService(ApplicationDbContext applicationDbContext) : IApplicationUserAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<ApplicationUser?> AddAsync(string userName, ApplicationUser applicationUser)
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

        if (string.IsNullOrWhiteSpace(applicationUser.UserName))
        {
            throw new Exception("UserName required.");
        }

        applicationUser.ApplicationUserUpdatedBy = user;
        applicationUser.NormalizedEmail = applicationUser.Email?.ToUpper();
        applicationUser.NormalizedUserName = applicationUser.UserName?.ToUpper();

        _applicationDbContext.Users.Add(applicationUser);

        await _applicationDbContext.SaveChangesAsync();

        return applicationUser;
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

    public async Task<ApplicationUser?> EditAsync(string userName, Guid id, ApplicationUser applicationUser)
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
            throw new Exception("Application role not found.");
        }

        if (string.IsNullOrWhiteSpace(applicationUser.Email))
        {
            throw new Exception("Email required.");
        }

        dbApplicationUser.ApplicationUserUpdatedBy = user;
        dbApplicationUser.Email = applicationUser.Email;
        dbApplicationUser.NormalizedEmail = applicationUser.Email?.ToUpper();
        dbApplicationUser.PhoneNumber = applicationUser.PhoneNumber;
        dbApplicationUser.UserName = applicationUser.UserName;
        dbApplicationUser.NormalizedUserName = applicationUser.UserName?.ToUpper();

        await _applicationDbContext.SaveChangesAsync();

        return dbApplicationUser;
    }

    public async Task<List<ApplicationUser>?> GetAllAsync()
    {
        return await _applicationDbContext.Users
            .Include(x => x.ApplicationUserRoles)
            .ThenInclude(x => x.ApplicationRole)
            .ToListAsync();
    }

    public async Task<ApplicationUser?> GetByIdAsync(Guid id)
    {
        return await _applicationDbContext.Users
        .Where(x => x.Id == id)
        .Include(x => x.ApplicationUserRoles)
        .ThenInclude(x => x.ApplicationRole)
        .FirstOrDefaultAsync();
    }
}
