using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class ToDoItemAdminService(ApplicationDbContext applicationDbContext) : IToDoItemAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<ToDoItemAdminDataTransferObject?> AddAsync(string userName, ToDoItemAdminDataTransferObject toDoItemAdminDataTransferObject)
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

        if (string.IsNullOrWhiteSpace(toDoItemAdminDataTransferObject.Title))
        {
            throw new Exception("Title required.");
        }

        // RequiredPropertyCodePlaceholder

        var toDoItem = ToDoItemAdminDataTransferObject.ToToDoItem(user, toDoItemAdminDataTransferObject);

        var result = await _applicationDbContext.ToDoItems.AddAsync(toDoItem);
        var databaseToDoItemAdminDataTransferObject = ToDoItemAdminDataTransferObject.FromToDoItem(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseToDoItemAdminDataTransferObject;
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

        var databaseToDoItem = await _applicationDbContext.ToDoItems.FindAsync(id);

        if (databaseToDoItem == null)
        {
            return false;
        }

        databaseToDoItem.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseToDoItem);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<ToDoItemAdminDataTransferObject?> EditAsync(string userName, Guid id, ToDoItemAdminDataTransferObject toDoItemAdminDataTransferObject)
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

        var databaseToDoItem = await _applicationDbContext.ToDoItems.FindAsync(id);

        if (databaseToDoItem == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder

        databaseToDoItem.ApplicationUserUpdatedBy = user;

        databaseToDoItem.Title = toDoItemAdminDataTransferObject.Title;
        databaseToDoItem.NormalizedTitle = toDoItemAdminDataTransferObject.Title.ToUpperInvariant();
        // EditDatabasePropertyCodePlaceholder

        await _applicationDbContext.SaveChangesAsync();

        return toDoItemAdminDataTransferObject;
    }

    public async Task<List<ToDoItemAdminDataTransferObject>?> GetAllAsync()
    {
        var result = await _applicationDbContext.ToDoItems.ToListAsync();

        if (result == null)
        {
            return null;
        }

        return result.Select(x => ToDoItemAdminDataTransferObject.FromToDoItem(x)).ToList();
    }

    public async Task<ToDoItemAdminDataTransferObject?> GetByIdAsync(Guid id)
    {
        var result = await _applicationDbContext.ToDoItems.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return ToDoItemAdminDataTransferObject.FromToDoItem(result);
    }
}
