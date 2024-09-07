using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationUserController(IApplicationUserAdminService adminApplicationUserService) : ControllerBase
{
    private readonly IApplicationUserAdminService _adminApplicationUserService = adminApplicationUserService;

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
    public async Task<ActionResult<ApplicationUser?>> Delete(Guid id)
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
    public async Task<ActionResult<ApplicationUser?>> Edit(Guid id, ApplicationUser applicationUser)
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
    public async Task<ActionResult<ApplicationUser?>> GetById(Guid id)
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
