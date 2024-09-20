using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class EntityNamePlaceholderController(IEntityNamePlaceholderAdminService toDoListAdminService) : ControllerBase
{
    private readonly IEntityNamePlaceholderAdminService _toDoListAdminService = toDoListAdminService;

    [HttpPost]
    public async Task<ActionResult<EntityNamePlaceholderAdminDataTransferObject?>> Add(EntityNamePlaceholderAdminDataTransferObject toDoListAdminDataTransferObject)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var databaseEntityNamePlaceholderAdminDataTransferObject = await _toDoListAdminService.AddAsync(userName, toDoListAdminDataTransferObject);

        return Ok(databaseEntityNamePlaceholderAdminDataTransferObject);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<EntityNamePlaceholderAdminDataTransferObject?>> Delete(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var result = await _toDoListAdminService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EntityNamePlaceholderAdminDataTransferObject?>> Edit(Guid id, EntityNamePlaceholderAdminDataTransferObject toDoListAdminDataTransferObject)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var databaseEntityNamePlaceholder = await _toDoListAdminService.EditAsync(userName, id, toDoListAdminDataTransferObject);

        return Ok(databaseEntityNamePlaceholder);
    }

    [HttpGet]
    public async Task<ActionResult<EntityNamePlaceholderAdminDataTransferObject>?> GetAll()
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var toDoListAdminDataTransferObjects = await _toDoListAdminService.GetAllAsync();

        return Ok(toDoListAdminDataTransferObjects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EntityNamePlaceholderAdminDataTransferObject?>> GetById(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var toDoListAdminDataTransferObject = await _toDoListAdminService.GetByIdAsync(id);

        return Ok(toDoListAdminDataTransferObject);
    }
}
