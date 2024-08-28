using AppNamePlaceholder.Shared.Entities;
using AppNamePlaceholder.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationRoleController(IApplicationRoleService applicationRoleService) : ControllerBase
{
    private readonly IApplicationRoleService _applicationRoleService = applicationRoleService;

    [HttpPost]
    public async Task<ActionResult<ApplicationRole>> Add(ApplicationRole applicationRole)
    {
        var userName = User.Identity?.Name;

        var addedApplicationRole = await _applicationRoleService.AddAsync(userName, applicationRole);

        return Ok(addedApplicationRole);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApplicationRole>> Delete(string id)
    {
        var userName = User.Identity?.Name;

        var result = await _applicationRoleService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApplicationRole>> Edit(string id, ApplicationRole applicationRole)
    {
        var userName = User.Identity?.Name;

        var updatedApplicationRole = await _applicationRoleService.EditAsync(userName, id, applicationRole);

        return Ok(updatedApplicationRole);
    }

    [HttpGet]
    public async Task<ActionResult<ApplicationRole>> GetAll()
    {
        var userName = User.Identity?.Name;

        var applicationRoles = await _applicationRoleService.GetAllAsync();

        return Ok(applicationRoles);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationRole>> GetById(string id)
    {
        var applicationRole = await _applicationRoleService.GetByIdAsync(id);

        return Ok(applicationRole);
    }
}
