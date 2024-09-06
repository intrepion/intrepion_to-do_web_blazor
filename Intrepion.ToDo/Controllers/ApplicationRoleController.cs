using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationRoleController(IAdminApplicationRoleService adminApplicationRoleService) : ControllerBase
{
    private readonly IAdminApplicationRoleService _adminApplicationRoleService = adminApplicationRoleService;

    [HttpPost]
    public async Task<ActionResult<ApplicationRole?>> Add(ApplicationRole applicationRole)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedApplicationRole = await _adminApplicationRoleService.AddAsync(userName, applicationRole);

        return Ok(addedApplicationRole);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApplicationRole?>> Delete(string id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var result = await _adminApplicationRoleService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApplicationRole?>> Edit(string id, ApplicationRole applicationRole)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedApplicationRole = await _adminApplicationRoleService.EditAsync(userName, id, applicationRole);

        return Ok(updatedApplicationRole);
    }

    [HttpGet]
    public async Task<ActionResult<ApplicationRole>?> GetAll()
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var applicationRoles = await _adminApplicationRoleService.GetAllAsync();

        return Ok(applicationRoles);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationRole?>> GetById(string id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var applicationRole = await _adminApplicationRoleService.GetByIdAsync(id);

        return Ok(applicationRole);
    }
}
