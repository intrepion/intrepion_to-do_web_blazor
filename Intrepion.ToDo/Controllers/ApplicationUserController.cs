using AppNamePlaceholder.Shared.Entities;
using AppNamePlaceholder.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationUserController(IApplicationUserService applicationUserService) : ControllerBase
{
    private readonly IApplicationUserService _applicationUserService = applicationUserService;

    [HttpPost]
    public async Task<ActionResult<ApplicationUser>> Add(ApplicationUser applicationUser)
    {
        var userName = User.Identity?.Name;

        var addedApplicationUser = await _applicationUserService.AddAsync(userName, applicationUser);

        return Ok(addedApplicationUser);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApplicationUser>> Delete(string id)
    {
        var userName = User.Identity?.Name;

        var result = await _applicationUserService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApplicationUser>> Edit(string id, ApplicationUser applicationUser)
    {
        var userName = User.Identity?.Name;

        var updatedApplicationUser = await _applicationUserService.EditAsync(userName, id, applicationUser);

        return Ok(updatedApplicationUser);
    }

    [HttpGet]
    public async Task<ActionResult<ApplicationUser>> GetAll()
    {
        var applicationUsers = await _applicationUserService.GetAllAsync();

        return Ok(applicationUsers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationUser>> GetById(string id)
    {
        var applicationUser = await _applicationUserService.GetByIdAsync(id);

        return Ok(applicationUser);
    }
}
