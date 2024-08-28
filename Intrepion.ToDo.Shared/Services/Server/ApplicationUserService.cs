using Intrepion.ToDo.Shared.Data;
using Intrepion.ToDo.Shared.Entities;
using Intrepion.ToDo.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.ToDo.Shared.Services.Server;

public class ApplicationUserService(ApplicationDbContext applicationDbContext) : IApplicationUserService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<ApplicationUser> AddAsync(ApplicationUser applicationUser)
    {
        if (string.IsNullOrWhiteSpace(applicationUser.Email))
        {
            throw new Exception("Email required.");
        }

        applicationUser.EmailConfirmed = false;
        applicationUser.NormalizedEmail = applicationUser.Email?.ToUpper();
        applicationUser.NormalizedUserName = applicationUser.Email?.ToUpper();
        applicationUser.UserName = applicationUser.Email;

        _applicationDbContext.Users.Add(applicationUser);

        await _applicationDbContext.SaveChangesAsync();

        return applicationUser;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var dbApplicationUser = await _applicationDbContext.Users.FindAsync(id);

        if (dbApplicationUser == null)
        {
            return false;
        }

        _applicationDbContext.Remove(dbApplicationUser);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<ApplicationUser> EditAsync(string id, ApplicationUser applicationUser)
    {
        var dbApplicationUser = await _applicationDbContext.Users.FindAsync(id);

        if (dbApplicationUser == null)
        {
            throw new Exception("Application user not found.");
        }

        if (string.IsNullOrWhiteSpace(dbApplicationUser.Email))
        {
            throw new Exception("Email required.");
        }

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
