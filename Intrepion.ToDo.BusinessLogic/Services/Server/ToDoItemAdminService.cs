using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class ToDoItemAdminService(ApplicationDbContext applicationDbContext) : IToDoItemAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<ToDoItem?> AddAsync(string userName, ToDoItem toDoItem)
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

        // if (string.IsNullOrWhiteSpace(toDoItem.PropertyNamePlaceholder))
        // {
        //     throw new Exception("Name required.");
        // }

        toDoItem.ApplicationUserUpdatedBy = user;
        // toDoItem.NormalizedPropertyNamePlaceholder = toDoItem.PropertyNamePlaceholder?.ToUpper();

        _applicationDbContext.ToDoItems.Add(toDoItem);

        await _applicationDbContext.SaveChangesAsync();

        return toDoItem;
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

        var dbToDoItem = await _applicationDbContext.ToDoItems.FindAsync(id);

        if (dbToDoItem == null)
        {
            return false;
        }

        dbToDoItem.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(dbToDoItem);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<ToDoItem?> EditAsync(string userName, Guid id, ToDoItem toDoItem)
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

        var dbToDoItem = await _applicationDbContext.ToDoItems.FindAsync(id);

        if (dbToDoItem == null)
        {
            throw new Exception("Application role not found.");
        }

        // if (string.IsNullOrWhiteSpace(toDoItem.PropertyNamePlaceholder))
        // {
        //     throw new Exception("PropertyNamePlaceholder required.");
        // }

        dbToDoItem.ApplicationUserUpdatedBy = user;
        // dbToDoItem.PropertyNamePlaceholder = toDoItem.PropertyNamePlaceholder;
        // dbToDoItem.NormalizedPropertyNamePlaceholder = toDoItem.PropertyNamePlaceholder?.ToUpper();

        await _applicationDbContext.SaveChangesAsync();

        return dbToDoItem;
    }

    public async Task<List<ToDoItem>?> GetAllAsync()
    {
        return await _applicationDbContext.ToDoItems.Include(x => x.ApplicationUserUpdatedBy).ToListAsync();
    }

    public async Task<ToDoItem?> GetByIdAsync(Guid id)
    {
        return await _applicationDbContext.ToDoItems.FindAsync(id);
    }
}
