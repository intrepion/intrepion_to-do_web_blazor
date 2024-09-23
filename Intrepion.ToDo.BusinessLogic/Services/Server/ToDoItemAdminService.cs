using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class ToDoItemAdminService(ApplicationDbContext applicationDbContext) : IToDoItemAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<ToDoItemAdminDto?> AddAsync(ToDoItemAdminDto toDoItemAdminDto)
    {
        if (string.IsNullOrWhiteSpace(toDoItemAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => toDoItemAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        // RequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(toDoItemAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        var toDoItem = ToDoItemAdminDto.ToToDoItem(user, toDoItemAdminDto);

        var result = await _applicationDbContext.ToDoItems.AddAsync(toDoItem);
        var databaseToDoItemAdminDto = ToDoItemAdminDto.FromToDoItem(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseToDoItemAdminDto;
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

    public async Task<ToDoItemAdminDto?> EditAsync(ToDoItemAdminDto toDoItemAdminDto)
    {
        if (string.IsNullOrWhiteSpace(toDoItemAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => toDoItemAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseToDoItem = await _applicationDbContext.ToDoItems.FindAsync(toDoItemAdminDto.Id);

        if (databaseToDoItem == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(toDoItemAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        databaseToDoItem.ApplicationUserUpdatedBy = user;

        databaseToDoItem.Title = toDoItemAdminDto.Title;
        databaseToDoItem.NormalizedTitle = toDoItemAdminDto.Title.ToUpperInvariant();
        // EditDatabasePropertyCodePlaceholder
        // databaseToDoItem.Title = toDoItemAdminDto.Title;
        // databaseToDoItem.NormalizedTitle = toDoItemAdminDto.Title.ToUpperInvariant();
        // databaseToDoItem.ToDoList = toDoItemAdminDto.ToDoList;

        await _applicationDbContext.SaveChangesAsync();

        return toDoItemAdminDto;
    }

    public async Task<List<ToDoItem>?> GetAllAsync(string userName)
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

        return await _applicationDbContext.ToDoItems.ToListAsync();
    }

    public async Task<ToDoItemAdminDto?> GetByIdAsync(string userName, Guid id)
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

        var result = await _applicationDbContext.ToDoItems.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return ToDoItemAdminDto.FromToDoItem(result);
    }
}
