﻿using Microsoft.AspNetCore.Mvc;
using Intrepion.ToDo.BusinessLogic.Entities;
using Intrepion.ToDo.BusinessLogic.Entities.DataTransferObjects;
using Intrepion.ToDo.BusinessLogic.Services;

namespace Intrepion.ToDo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationRoleController(IApplicationRoleAdminService applicationRoleAdminService) : ControllerBase
{
    private readonly IApplicationRoleAdminService _applicationRoleAdminService = applicationRoleAdminService;

    [HttpPost]
    public async Task<ActionResult<ApplicationRoleAdminDataTransferObject?>> Add(ApplicationRoleAdminDataTransferObject applicationRoleAdminDataTransferObject)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var databaseApplicationRoleAdminDataTransferObject = await _applicationRoleAdminService.AddAsync(userName, applicationRoleAdminDataTransferObject);

        return Ok(databaseApplicationRoleAdminDataTransferObject);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApplicationRoleAdminDataTransferObject?>> Delete(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var result = await _applicationRoleAdminService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApplicationRoleAdminDataTransferObject?>> Edit(Guid id, ApplicationRoleAdminDataTransferObject applicationRoleAdminDataTransferObject)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var databaseApplicationRole = await _applicationRoleAdminService.EditAsync(userName, id, applicationRoleAdminDataTransferObject);

        return Ok(databaseApplicationRole);
    }

    [HttpGet]
    public async Task<ActionResult<ApplicationRoleAdminDataTransferObject>?> GetAll()
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var applicationRoleAdminDataTransferObjects = await _applicationRoleAdminService.GetAllAsync();

        return Ok(applicationRoleAdminDataTransferObjects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationRoleAdminDataTransferObject?>> GetById(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var applicationRoleAdminDataTransferObject = await _applicationRoleAdminService.GetByIdAsync(id);

        return Ok(applicationRoleAdminDataTransferObject);
    }
}
