using Intrepion.ToDo.BusinessLogic.Data;
using Intrepion.ToDo.BusinessLogic.Entities.Dtos.Admin;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.ToDo.BusinessLogic.Repositories.Admin.Server;

public class ToDoItemAdminRepository(ApplicationDbContext applicationDbContext) : IToDoItemAdminRepository
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

        if (string.IsNullOrWhiteSpace(toDoItemAdminDto?.Title ?? string.Empty))
        {
            throw new Exception("Title required.");
        }

        // AddRequiredPropertyCodePlaceholder

        var toDoItem = ToDoItemAdminDto.ToToDoItem(user, toDoItemAdminDto);

        toDoItem.NormalizedTitle = toDoItemAdminDto?.Title ?? string.Empty.ToUpperInvariant();
        // AddDatabasePropertyCodePlaceholder

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

        if (string.IsNullOrWhiteSpace(toDoItemAdminDto?.Title ?? string.Empty))
        {
            throw new Exception("Title required.");
        }

        // EditRequiredPropertyCodePlaceholder

        databaseToDoItem.ApplicationUserUpdatedBy = user;

        databaseToDoItem.ToDoList = toDoItemAdminDto?.ToDoList;
        databaseToDoItem.Title = toDoItemAdminDto?.Title ?? string.Empty;
        databaseToDoItem.NormalizedTitle = toDoItemAdminDto?.Title ?? string.Empty.ToUpperInvariant();
        // EditDatabasePropertyCodePlaceholder

        await _applicationDbContext.SaveChangesAsync();

        return toDoItemAdminDto;
    }

    public async Task<List<ToDoItemAdminDto>?> GetAllAsync(string userName)
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

        return await _applicationDbContext
            .ToDoItems

            // IncludeTableCodePlaceholder

            .Select(x => ToDoItemAdminDto.FromToDoItem(x))
            .AsNoTracking()
            .ToListAsync();
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
