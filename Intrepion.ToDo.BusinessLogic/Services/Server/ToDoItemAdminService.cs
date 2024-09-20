using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class EntityNamePlaceholderAdminService(ApplicationDbContext applicationDbContext) : IEntityNamePlaceholderAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<EntityNamePlaceholderAdminDataTransferObject?> AddAsync(string userName, EntityNamePlaceholderAdminDataTransferObject EntityLowercaseNamePlaceholderAdminDataTransferObject)
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

        // RequiredPropertyCodePlaceholder

        var EntityLowercaseNamePlaceholder = EntityNamePlaceholderAdminDataTransferObject.ToEntityNamePlaceholder(user, EntityLowercaseNamePlaceholderAdminDataTransferObject);

        var result = await _applicationDbContext.EntityNamePlaceholders.AddAsync(EntityLowercaseNamePlaceholder);
        var databaseEntityNamePlaceholderAdminDataTransferObject = EntityNamePlaceholderAdminDataTransferObject.FromEntityNamePlaceholder(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseEntityNamePlaceholderAdminDataTransferObject;
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

        var databaseEntityNamePlaceholder = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (databaseEntityNamePlaceholder == null)
        {
            return false;
        }

        databaseEntityNamePlaceholder.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseEntityNamePlaceholder);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<EntityNamePlaceholderAdminDataTransferObject?> EditAsync(string userName, Guid id, EntityNamePlaceholderAdminDataTransferObject EntityLowercaseNamePlaceholderAdminDataTransferObject)
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

        var databaseEntityNamePlaceholder = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (databaseEntityNamePlaceholder == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder

        databaseEntityNamePlaceholder.ApplicationUserUpdatedBy = user;

        // EditDatabasePropertyCodePlaceholder

        await _applicationDbContext.SaveChangesAsync();

        return EntityLowercaseNamePlaceholderAdminDataTransferObject;
    }

    public async Task<List<EntityNamePlaceholderAdminDataTransferObject>?> GetAllAsync()
    {
        var result = await _applicationDbContext.TableNamePlaceholder.ToListAsync();

        if (result == null)
        {
            return null;
        }

        return result.Select(x => EntityNamePlaceholderAdminDataTransferObject.FromEntityNamePlaceholder(x)).ToList();
    }

    public async Task<EntityNamePlaceholderAdminDataTransferObject?> GetByIdAsync(Guid id)
    {
        var result = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return EntityNamePlaceholderAdminDataTransferObject.FromEntityNamePlaceholder(result);
    }
}
