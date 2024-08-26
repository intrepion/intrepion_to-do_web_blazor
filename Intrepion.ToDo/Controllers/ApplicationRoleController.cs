using Intrepion.ToDo.Shared.Entities;
using Intrepion.ToDo.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace Intrepion.ToDo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationRoleController(IApplicationRoleService applicationRoleService) : ControllerBase
{
    private readonly IApplicationRoleService _applicationRoleService = applicationRoleService;

    [HttpPost]
    public async Task<ActionResult<ApplicationRole>> Add(ApplicationRole applicationRole)
    {
        var addedApplicationRole = await _applicationRoleService.AddAsync(applicationRole);

        return Ok(addedApplicationRole);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApplicationRole>> Delete(Guid id)
    {
        var result = await _applicationRoleService.DeleteAsync(id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApplicationRole>> Edit(Guid id, ApplicationRole applicationRole)
    {
        var updatedApplicationRole = await _applicationRoleService.EditAsync(id, applicationRole);

        return Ok(updatedApplicationRole);
    }

    [HttpGet]
    public async Task<ActionResult<ApplicationRole>> GetById(Guid id)
    {
        var applicationRole = await _applicationRoleService.GetByIdAsync(id);

        return Ok(applicationRole);
    }
}
