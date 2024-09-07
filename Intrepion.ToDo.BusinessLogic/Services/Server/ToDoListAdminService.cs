using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class ToDoListAdminService(ApplicationDbContext applicationDbContext) : IToDoListAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<ToDoList?> AddAsync(string userName, ToDoList EntityLowercaseNamePlaceholder)
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

        _applicationDbContext.ToDoLists.Add(EntityLowercaseNamePlaceholder);

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

        var dbToDoList = await _applicationDbContext.ToDoLists.FindAsync(id);

        if (dbToDoList == null)
        {
            return false;
        }

        dbToDoList.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(dbToDoList);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<ToDoList?> EditAsync(string userName, Guid id, ToDoList EntityLowercaseNamePlaceholder)
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

        var dbToDoList = await _applicationDbContext.ToDoLists.FindAsync(id);

        if (dbToDoList == null)
        {
            throw new Exception("Application role not found.");
        }

        // if (string.IsNullOrWhiteSpace(EntityLowercaseNamePlaceholder.PropertyNamePlaceholder))
        // {
        //     throw new Exception("PropertyNamePlaceholder required.");
        // }

        dbToDoList.ApplicationUserUpdatedBy = user;
        // dbToDoList.PropertyNamePlaceholder = EntityLowercaseNamePlaceholder.PropertyNamePlaceholder;
        // dbToDoList.NormalizedPropertyNamePlaceholder = EntityLowercaseNamePlaceholder.PropertyNamePlaceholder?.ToUpper();

        await _applicationDbContext.SaveChangesAsync();

        return dbToDoList;
    }

    public async Task<List<ToDoList>?> GetAllAsync()
    {
        return await _applicationDbContext.ToDoLists.Include(x => x.ApplicationUserUpdatedBy).ToListAsync();
    }

    public async Task<ToDoList?> GetByIdAsync(Guid id)
    {
        return await _applicationDbContext.ToDoLists.FindAsync(id);
    }
}
