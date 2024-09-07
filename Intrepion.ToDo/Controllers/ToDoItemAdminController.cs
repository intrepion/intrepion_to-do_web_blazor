using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoItemAdminController(IToDoItemAdminService toDoItemAdminService) : ControllerBase
{
    private readonly IToDoItemAdminService _toDoItemAdminService = toDoItemAdminService;

    [HttpPost]
    public async Task<ActionResult<ToDoItem?>> Add(ToDoItem toDoItem)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedToDoItem = await _toDoItemAdminService.AddAsync(userName, toDoItem);

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

        var result = await _toDoItemAdminService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ToDoItem?>> Edit(Guid id, ToDoItem toDoItem)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedToDoItem = await _toDoItemAdminService.EditAsync(userName, id, toDoItem);

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

        var toDoItems = await _toDoItemAdminService.GetAllAsync();

        return Ok(toDoItems);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItem?>> GetById(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var toDoItem = await _toDoItemAdminService.GetByIdAsync(id);

        return Ok(toDoItem);
    }
}
