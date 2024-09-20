using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class ToDoListAdminService(ApplicationDbContext applicationDbContext) : IToDoListAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<ToDoListAdminDataTransferObject?> AddAsync(string userName, ToDoListAdminDataTransferObject toDoListAdminDataTransferObject)
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

        if (string.IsNullOrWhiteSpace(toDoListAdminDataTransferObject.Title))
        {
            throw new Exception("Title required.");
        }

        // RequiredPropertyCodePlaceholder

        var toDoList = ToDoListAdminDataTransferObject.ToToDoList(user, toDoListAdminDataTransferObject);

        var result = await _applicationDbContext.ToDoLists.AddAsync(toDoList);
        var databaseToDoListAdminDataTransferObject = ToDoListAdminDataTransferObject.FromToDoList(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseToDoListAdminDataTransferObject;
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

        var databaseToDoList = await _applicationDbContext.ToDoLists.FindAsync(id);

        if (databaseToDoList == null)
        {
            return false;
        }

        databaseToDoList.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseToDoList);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<ToDoListAdminDataTransferObject?> EditAsync(string userName, Guid id, ToDoListAdminDataTransferObject toDoListAdminDataTransferObject)
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

        var databaseToDoList = await _applicationDbContext.ToDoLists.FindAsync(id);

        if (databaseToDoList == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder

        databaseToDoList.ApplicationUserUpdatedBy = user;

        databaseToDoList.Title = toDoListAdminDataTransferObject.Title;
        databaseToDoList.NormalizedTitle = toDoListAdminDataTransferObject.Title.ToUpperInvariant();
        // EditDatabasePropertyCodePlaceholder

        await _applicationDbContext.SaveChangesAsync();

        return toDoListAdminDataTransferObject;
    }

    public async Task<List<ToDoListAdminDataTransferObject>?> GetAllAsync()
    {
        var result = await _applicationDbContext.ToDoLists.ToListAsync();

        if (result == null)
        {
            return null;
        }

        return result.Select(x => ToDoListAdminDataTransferObject.FromToDoList(x)).ToList();
    }

    public async Task<ToDoListAdminDataTransferObject?> GetByIdAsync(Guid id)
    {
        var result = await _applicationDbContext.ToDoLists.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return ToDoListAdminDataTransferObject.FromToDoList(result);
    }
}
