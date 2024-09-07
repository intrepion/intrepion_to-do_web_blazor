using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntityNamePlaceholderAdminController(IEntityNamePlaceholderAdminService EntityLowercaseNamePlaceholderAdminService) : ControllerBase
{
    private readonly IEntityNamePlaceholderAdminService _EntityLowercaseNamePlaceholderAdminService = EntityLowercaseNamePlaceholderAdminService;

    [HttpPost]
    public async Task<ActionResult<EntityNamePlaceholder?>> Add(EntityNamePlaceholder EntityLowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedEntityNamePlaceholder = await _EntityLowercaseNamePlaceholderAdminService.AddAsync(userName, EntityLowercaseNamePlaceholder);

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

        var result = await _EntityLowercaseNamePlaceholderAdminService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EntityNamePlaceholder?>> Edit(Guid id, EntityNamePlaceholder EntityLowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedEntityNamePlaceholder = await _EntityLowercaseNamePlaceholderAdminService.EditAsync(userName, id, EntityLowercaseNamePlaceholder);

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

        var TableLowercaseNamePlaceholder = await _EntityLowercaseNamePlaceholderAdminService.GetAllAsync();

        return Ok(TableLowercaseNamePlaceholder);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EntityNamePlaceholder?>> GetById(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var EntityLowercaseNamePlaceholder = await _EntityLowercaseNamePlaceholderAdminService.GetByIdAsync(id);

        return Ok(EntityLowercaseNamePlaceholder);
    }
}
