using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class EntityNamePlaceholderController(IEntityNamePlaceholderAdminService EntityLowercaseNamePlaceholderAdminService) : ControllerBase
{
    private readonly IEntityNamePlaceholderAdminService _EntityLowercaseNamePlaceholderAdminService = EntityLowercaseNamePlaceholderAdminService;

    [HttpPost]
    public async Task<ActionResult<EntityNamePlaceholderAdminDataTransferObject?>> Add(EntityNamePlaceholderAdminDataTransferObject EntityLowercaseNamePlaceholderAdminDataTransferObject)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var databaseEntityNamePlaceholderAdminDataTransferObject = await _EntityLowercaseNamePlaceholderAdminService.AddAsync(userName, EntityLowercaseNamePlaceholderAdminDataTransferObject);

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

        var result = await _EntityLowercaseNamePlaceholderAdminService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EntityNamePlaceholderAdminDataTransferObject?>> Edit(Guid id, EntityNamePlaceholderAdminDataTransferObject EntityLowercaseNamePlaceholderAdminDataTransferObject)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var databaseEntityNamePlaceholder = await _EntityLowercaseNamePlaceholderAdminService.EditAsync(userName, id, EntityLowercaseNamePlaceholderAdminDataTransferObject);

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

        var EntityLowercaseNamePlaceholderAdminDataTransferObjects = await _EntityLowercaseNamePlaceholderAdminService.GetAllAsync();

        return Ok(EntityLowercaseNamePlaceholderAdminDataTransferObjects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EntityNamePlaceholderAdminDataTransferObject?>> GetById(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var EntityLowercaseNamePlaceholderAdminDataTransferObject = await _EntityLowercaseNamePlaceholderAdminService.GetByIdAsync(id);

        return Ok(EntityLowercaseNamePlaceholderAdminDataTransferObject);
    }
}
