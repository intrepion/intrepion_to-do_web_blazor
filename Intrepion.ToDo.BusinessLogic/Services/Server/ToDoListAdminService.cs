using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class ToDoListAdminService(ApplicationDbContext applicationDbContext) : IToDoListAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<ToDoListAdminDto?> AddAsync(ToDoListAdminDto toDoListAdminDto)
    {
        if (string.IsNullOrWhiteSpace(toDoListAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => toDoListAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        // AddRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(toDoListAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        var toDoList = ToDoListAdminDto.ToToDoList(user, toDoListAdminDto);

        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.ToDoLists.AddAsync(toDoList);
        var databaseToDoListAdminDto = ToDoListAdminDto.FromToDoList(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseToDoListAdminDto;
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

    public async Task<ToDoListAdminDto?> EditAsync(ToDoListAdminDto toDoListAdminDto)
    {
        if (string.IsNullOrWhiteSpace(toDoListAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => toDoListAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseToDoList = await _applicationDbContext.ToDoLists.FindAsync(toDoListAdminDto.Id);

        if (databaseToDoList == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(toDoListAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        databaseToDoList.ApplicationUserUpdatedBy = user;

        databaseToDoList.Title = toDoListAdminDto.Title;
        // EditDatabasePropertyCodePlaceholder
        // databaseToDoList.Title = toDoListAdminDto.Title;
        // databaseToDoList.NormalizedTitle = toDoListAdminDto.Title.ToUpperInvariant();
        // databaseToDoList.ToDoList = toDoListAdminDto.ToDoList;

        await _applicationDbContext.SaveChangesAsync();

        return toDoListAdminDto;
    }

    public async Task<List<ToDoList>?> GetAllAsync(string userName)
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

        return await _applicationDbContext.ToDoLists

            .Include(x => x.ListItems)
    // IncludeTableCodePlaceholder

            .ToListAsync();
    }

    public async Task<ToDoListAdminDto?> GetByIdAsync(string userName, Guid id)
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

        var result = await _applicationDbContext.ToDoLists.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return ToDoListAdminDto.FromToDoList(result);
    }
}
