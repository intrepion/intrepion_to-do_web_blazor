﻿using Intrepion.ToDo.BusinessLogic.Data;
using Intrepion.ToDo.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.ToDo.BusinessLogic.Services.Server;

public class ApplicationRoleService(ApplicationDbContext applicationDbContext) : IApplicationRoleService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<ApplicationRole> AddAsync(string userName, ApplicationRole applicationRole)
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

        if (string.IsNullOrWhiteSpace(applicationRole.Name))
        {
            throw new Exception("Name required.");
        }

        applicationRole.ApplicationUserUpdatedBy = user;
        applicationRole.NormalizedName = applicationRole.Name?.ToUpper();

        _applicationDbContext.Roles.Add(applicationRole);

        await _applicationDbContext.SaveChangesAsync();

        return applicationRole;
    }

    public async Task<bool> DeleteAsync(string userName, string id)
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

        var dbApplicationRole = await _applicationDbContext.Roles.FindAsync(id);

        if (dbApplicationRole == null)
        {
            return false;
        }

        dbApplicationRole.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(dbApplicationRole);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<ApplicationRole> EditAsync(string userName, string id, ApplicationRole applicationRole)
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

        var dbApplicationRole = await _applicationDbContext.Roles.FindAsync(id);

        if (dbApplicationRole == null)
        {
            throw new Exception("Application role not found.");
        }

        if (string.IsNullOrWhiteSpace(applicationRole.Name))
        {
            throw new Exception("Name required.");
        }

        dbApplicationRole.ApplicationUserUpdatedBy = user;
        dbApplicationRole.Name = applicationRole.Name;
        dbApplicationRole.NormalizedName = applicationRole.Name?.ToUpper();

        await _applicationDbContext.SaveChangesAsync();

        return dbApplicationRole;
    }

    public async Task<List<ApplicationRole>> GetAllAsync()
    {
        var applicationRoles = await _applicationDbContext.Roles.Include(x => x.ApplicationUserUpdatedBy).ToListAsync();

        return applicationRoles;
    }

    public async Task<ApplicationRole> GetByIdAsync(string id)
    {
        var role = await _applicationDbContext.Roles.FindAsync(id);

        if (role == null)
        {
            return new ApplicationRole();
        }

        return role;
    }
}
