using AppNamePlaceholder.BusinessLogic.Entities;
using AppNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoItemAdminController(IToDoItemAdminService LowercaseNamePlaceholderAdminService) : ControllerBase
{
    private readonly IToDoItemAdminService _LowercaseNamePlaceholderAdminService = LowercaseNamePlaceholderAdminService;

    [HttpPost]
    public async Task<ActionResult<ToDoItem?>> Add(ToDoItem LowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedToDoItem = await _LowercaseNamePlaceholderAdminService.AddAsync(userName, LowercaseNamePlaceholder);

        return Ok(addedToDoItem);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ToDoItem?>> Delete(Guid id)
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
    public async Task<ActionResult<ToDoItem?>> Edit(Guid id, ToDoItem LowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedToDoItem = await _LowercaseNamePlaceholderAdminService.EditAsync(userName, id, LowercaseNamePlaceholder);

        return Ok(updatedToDoItem);
    }

    [HttpGet]
    public async Task<ActionResult<ToDoItem>?> GetAll()
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
    public async Task<ActionResult<ToDoItem?>> GetById(Guid id)
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
