using Intrepion.ToDo.BusinessLogic.Entities;
using Intrepion.ToDo.BusinessLogic.Entities.DataTransferObjects;
using Intrepion.ToDo.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Intrepion.ToDo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminApplicationUserEditDataTransferObjectController(IApplicationUserService applicationUserService) : ControllerBase
{
    private readonly IApplicationUserService _applicationUserService = applicationUserService;

    [HttpPost]
    public async Task<ActionResult<AdminApplicationUserEditDataTransferObject?>> Add(AdminApplicationUserEditDataTransferObject applicationUser)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedAdminApplicationUserEditDataTransferObject = await _applicationUserService.AddAsync(userName, applicationUser);

        return Ok(addedAdminApplicationUserEditDataTransferObject);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<AdminApplicationUserEditDataTransferObject?>> Delete(string id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var result = await _applicationUserService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AdminApplicationUserEditDataTransferObject?>> Edit(string id, AdminApplicationUserEditDataTransferObject applicationUser)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedAdminApplicationUserEditDataTransferObject = await _applicationUserService.EditAsync(userName, id, applicationUser);

        return Ok(updatedAdminApplicationUserEditDataTransferObject);
    }

    [HttpGet]
    public async Task<ActionResult<List<AdminApplicationUserListItemDataTransferObject>?>> GetAll()
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var applicationUsers = await _applicationUserService.GetAllAsync();

        return Ok(applicationUsers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AdminApplicationUserEditDataTransferObject?>> GetById(string id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var applicationUser = await _applicationUserService.GetByIdAsync(id);

        return Ok(applicationUser);
    }
}
