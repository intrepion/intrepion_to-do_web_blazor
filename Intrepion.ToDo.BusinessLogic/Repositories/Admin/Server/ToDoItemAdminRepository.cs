﻿using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin.Server;

public class EntityNamePlaceholderAdminRepository(ApplicationDbContext applicationDbContext) : IEntityNamePlaceholderAdminRepository
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<EntityNamePlaceholderAdminDto?> AddAsync(EntityNamePlaceholderAdminDto toDoItemAdminDto)
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

        // AddRequiredPropertyCodePlaceholder

        var toDoItem = EntityNamePlaceholderAdminDto.ToEntityNamePlaceholder(user, toDoItemAdminDto);

        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.TableNamePlaceholder.AddAsync(toDoItem);
        var databaseEntityNamePlaceholderAdminDto = EntityNamePlaceholderAdminDto.FromEntityNamePlaceholder(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseEntityNamePlaceholderAdminDto;
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

    public async Task<EntityNamePlaceholderAdminDto?> EditAsync(EntityNamePlaceholderAdminDto toDoItemAdminDto)
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

        var databaseEntityNamePlaceholder = await _applicationDbContext.TableNamePlaceholder.FindAsync(toDoItemAdminDto.Id);

        if (databaseEntityNamePlaceholder == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder

        databaseEntityNamePlaceholder.ApplicationUserUpdatedBy = user;

        // EditDatabasePropertyCodePlaceholder

        await _applicationDbContext.SaveChangesAsync();

        return toDoItemAdminDto;
    }

    public async Task<List<EntityNamePlaceholderAdminDto>?> GetAllAsync(string userName)
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

        return await _applicationDbContext.TableNamePlaceholder

            // IncludeTableCodePlaceholder

            .Select(x => EntityNamePlaceholderAdminDto.FromEntityNamePlaceholder(x))
            .ToListAsync();
    }

    public async Task<EntityNamePlaceholderAdminDto?> GetByIdAsync(string userName, Guid id)
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

        var result = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return EntityNamePlaceholderAdminDto.FromEntityNamePlaceholder(result);
    }
}
