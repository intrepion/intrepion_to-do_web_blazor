using Microsoft.AspNetCore.Mvc;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;
using ApplicationNamePlaceholder.BusinessLogic.Services;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationUserController(IApplicationUserAdminService adminApplicationUserService) : ControllerBase
{
    private readonly IApplicationUserAdminService _adminApplicationUserService = adminApplicationUserService;

    [HttpPost]
    public async Task<ActionResult<ApplicationUserAdminDataTransferObject?>> Add(ApplicationUserAdminDataTransferObject applicationUserAdminDataTransferObject)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var databaseApplicationUserAdminDataTransferObject = await _adminApplicationUserService.AddAsync(userName, applicationUserAdminDataTransferObject);

        return Ok(databaseApplicationUserAdminDataTransferObject);
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
    public async Task<ActionResult<ApplicationUserAdminDataTransferObject?>> Edit(Guid id, ApplicationUserAdminDataTransferObject applicationUserAdminDataTransferObject)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var databaseApplicationUserAdminDataTransferObject = await _adminApplicationUserService.EditAsync(userName, id, applicationUserAdminDataTransferObject);

        return Ok(databaseApplicationUserAdminDataTransferObject);
    }

    [HttpGet]
    public async Task<ActionResult<List<ApplicationUserAdminDataTransferObject>?>> GetAll()
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var applicationUserAdminDataTransferObjects = await _adminApplicationUserService.GetAllAsync();

        return Ok(applicationUserAdminDataTransferObjects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationUserAdminDataTransferObject?>> GetById(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var applicationUserAdminDataTransferObject = await _adminApplicationUserService.GetByIdAsync(id);

        return Ok(applicationUserAdminDataTransferObject);
    }
}
