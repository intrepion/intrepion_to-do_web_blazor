﻿using Intrepion.ToDo.BusinessLogic.Entities;
using Intrepion.ToDo.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Intrepion.ToDo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationUserController(IAdminApplicationUserService adminApplicationUserService) : ControllerBase
{
    private readonly IAdminApplicationUserService _adminApplicationUserService = adminApplicationUserService;

    [HttpPost]
    public async Task<ActionResult<ApplicationUser?>> Add(ApplicationUser applicationUser)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedApplicationUser = await _adminApplicationUserService.AddAsync(userName, applicationUser);

        return Ok(addedApplicationUser);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApplicationUser?>> Delete(string id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var result = await _adminApplicationUserService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApplicationUser?>> Edit(string id, ApplicationUser applicationUser)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedApplicationUser = await _adminApplicationUserService.EditAsync(userName, id, applicationUser);

        return Ok(updatedApplicationUser);
    }

    [HttpGet]
    public async Task<ActionResult<List<ApplicationUser>?>> GetAll()
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var applicationUsers = await _adminApplicationUserService.GetAllAsync();

        return Ok(applicationUsers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationUser?>> GetById(string id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var applicationUser = await _adminApplicationUserService.GetByIdAsync(id);

        return Ok(applicationUser);
    }
}
