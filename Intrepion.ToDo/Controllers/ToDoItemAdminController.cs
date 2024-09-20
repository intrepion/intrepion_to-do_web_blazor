using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class EntityNamePlaceholderController(IEntityNamePlaceholderAdminService toDoItemAdminService) : ControllerBase
{
    private readonly IEntityNamePlaceholderAdminService _toDoItemAdminService = toDoItemAdminService;

    [HttpPost]
    public async Task<ActionResult<EntityNamePlaceholderAdminDataTransferObject?>> Add(EntityNamePlaceholderAdminDataTransferObject toDoItemAdminDataTransferObject)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var databaseEntityNamePlaceholderAdminDataTransferObject = await _toDoItemAdminService.AddAsync(userName, toDoItemAdminDataTransferObject);

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

        var result = await _toDoItemAdminService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EntityNamePlaceholderAdminDataTransferObject?>> Edit(Guid id, EntityNamePlaceholderAdminDataTransferObject toDoItemAdminDataTransferObject)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var databaseEntityNamePlaceholder = await _toDoItemAdminService.EditAsync(userName, id, toDoItemAdminDataTransferObject);

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

        var toDoItemAdminDataTransferObjects = await _toDoItemAdminService.GetAllAsync();

        return Ok(toDoItemAdminDataTransferObjects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EntityNamePlaceholderAdminDataTransferObject?>> GetById(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var toDoItemAdminDataTransferObject = await _toDoItemAdminService.GetByIdAsync(id);

        return Ok(toDoItemAdminDataTransferObject);
    }
}
