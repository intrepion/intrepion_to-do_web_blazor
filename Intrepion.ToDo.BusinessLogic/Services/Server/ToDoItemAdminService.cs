using AppNamePlaceholder.BusinessLogic.Data;
using AppNamePlaceholder.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppNamePlaceholder.BusinessLogic.Services.Server;

public class EntityNamePlaceholderAdminService(ApplicationDbContext applicationDbContext) : IEntityNamePlaceholderAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<EntityNamePlaceholder?> AddAsync(string userName, EntityNamePlaceholder LowercaseNamePlaceholder)
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

        // if (string.IsNullOrWhiteSpace(LowercaseNamePlaceholder.PropertyNamePlaceholder))
        // {
        //     throw new Exception("Name required.");
        // }

        LowercaseNamePlaceholder.ApplicationUserUpdatedBy = user;
        // LowercaseNamePlaceholder.NormalizedPropertyNamePlaceholder = LowercaseNamePlaceholder.PropertyNamePlaceholder?.ToUpper();

        _applicationDbContext.PluralNamePlaceholder.Add(LowercaseNamePlaceholder);

        await _applicationDbContext.SaveChangesAsync();

        return LowercaseNamePlaceholder;
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

        var dbEntityNamePlaceholder = await _applicationDbContext.PluralNamePlaceholder.FindAsync(id);

        if (dbEntityNamePlaceholder == null)
        {
            return false;
        }

        dbEntityNamePlaceholder.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(dbEntityNamePlaceholder);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<EntityNamePlaceholder?> EditAsync(string userName, Guid id, EntityNamePlaceholder LowercaseNamePlaceholder)
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

        var dbEntityNamePlaceholder = await _applicationDbContext.PluralNamePlaceholder.FindAsync(id);

        if (dbEntityNamePlaceholder == null)
        {
            throw new Exception("Application role not found.");
        }

        // if (string.IsNullOrWhiteSpace(LowercaseNamePlaceholder.PropertyNamePlaceholder))
        // {
        //     throw new Exception("PropertyNamePlaceholder required.");
        // }

        dbEntityNamePlaceholder.ApplicationUserUpdatedBy = user;
        // dbEntityNamePlaceholder.PropertyNamePlaceholder = LowercaseNamePlaceholder.PropertyNamePlaceholder;
        // dbEntityNamePlaceholder.NormalizedPropertyNamePlaceholder = LowercaseNamePlaceholder.PropertyNamePlaceholder?.ToUpper();

        await _applicationDbContext.SaveChangesAsync();

        return dbEntityNamePlaceholder;
    }

    public async Task<List<EntityNamePlaceholder>?> GetAllAsync()
    {
        return await _applicationDbContext.PluralNamePlaceholder.Include(x => x.ApplicationUserUpdatedBy).ToListAsync();
    }

    public async Task<EntityNamePlaceholder?> GetByIdAsync(Guid id)
    {
        return await _applicationDbContext.PluralNamePlaceholder.FindAsync(id);
    }
}
