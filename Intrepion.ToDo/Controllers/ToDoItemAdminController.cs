using AppNamePlaceholder.BusinessLogic.Entities;
using AppNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntityNamePlaceholderAdminController(IEntityNamePlaceholderAdminService LowercaseNamePlaceholderAdminService) : ControllerBase
{
    private readonly IEntityNamePlaceholderAdminService _LowercaseNamePlaceholderAdminService = LowercaseNamePlaceholderAdminService;

    [HttpPost]
    public async Task<ActionResult<EntityNamePlaceholder?>> Add(EntityNamePlaceholder LowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedEntityNamePlaceholder = await _LowercaseNamePlaceholderAdminService.AddAsync(userName, LowercaseNamePlaceholder);

        return Ok(addedEntityNamePlaceholder);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<EntityNamePlaceholder?>> Delete(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var result = await _LowercaseNamePlaceholderAdminService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EntityNamePlaceholder?>> Edit(Guid id, EntityNamePlaceholder LowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedEntityNamePlaceholder = await _LowercaseNamePlaceholderAdminService.EditAsync(userName, id, LowercaseNamePlaceholder);

        return Ok(updatedEntityNamePlaceholder);
    }

    [HttpGet]
    public async Task<ActionResult<EntityNamePlaceholder>?> GetAll()
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var LowercaseNamePlaceholders = await _LowercaseNamePlaceholderAdminService.GetAllAsync();

        return Ok(LowercaseNamePlaceholders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EntityNamePlaceholder?>> GetById(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var LowercaseNamePlaceholder = await _LowercaseNamePlaceholderAdminService.GetByIdAsync(id);

        return Ok(LowercaseNamePlaceholder);
    }
}
