using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class EntityNamePlaceholderAdminService(ApplicationDbContext applicationDbContext) : IEntityNamePlaceholderAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<EntityNamePlaceholder?> AddAsync(string userName, EntityNamePlaceholder EntityLowercaseNamePlaceholder)
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

        // if (string.IsNullOrWhiteSpace(EntityLowercaseNamePlaceholder.PropertyNamePlaceholder))
        // {
        //     throw new Exception("Name required.");
        // }

        EntityLowercaseNamePlaceholder.ApplicationUserUpdatedBy = user;
        // EntityLowercaseNamePlaceholder.NormalizedPropertyNamePlaceholder = EntityLowercaseNamePlaceholder.PropertyNamePlaceholder?.ToUpper();

        _applicationDbContext.TableNamePlaceholder.Add(EntityLowercaseNamePlaceholder);

        await _applicationDbContext.SaveChangesAsync();

        return EntityLowercaseNamePlaceholder;
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

        var dbEntityNamePlaceholder = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

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

    public async Task<EntityNamePlaceholder?> EditAsync(string userName, Guid id, EntityNamePlaceholder EntityLowercaseNamePlaceholder)
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

        var dbEntityNamePlaceholder = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (dbEntityNamePlaceholder == null)
        {
            throw new Exception("Application role not found.");
        }

        // if (string.IsNullOrWhiteSpace(EntityLowercaseNamePlaceholder.PropertyNamePlaceholder))
        // {
        //     throw new Exception("PropertyNamePlaceholder required.");
        // }

        dbEntityNamePlaceholder.ApplicationUserUpdatedBy = user;
        // dbEntityNamePlaceholder.PropertyNamePlaceholder = EntityLowercaseNamePlaceholder.PropertyNamePlaceholder;
        // dbEntityNamePlaceholder.NormalizedPropertyNamePlaceholder = EntityLowercaseNamePlaceholder.PropertyNamePlaceholder?.ToUpper();

        await _applicationDbContext.SaveChangesAsync();

        return dbEntityNamePlaceholder;
    }

    public async Task<List<EntityNamePlaceholder>?> GetAllAsync()
    {
        return await _applicationDbContext.TableNamePlaceholder.Include(x => x.ApplicationUserUpdatedBy).ToListAsync();
    }

    public async Task<EntityNamePlaceholder?> GetByIdAsync(Guid id)
    {
        return await _applicationDbContext.TableNamePlaceholder.FindAsync(id);
    }
}
