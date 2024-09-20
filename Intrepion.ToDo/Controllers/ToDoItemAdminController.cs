using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class ToDoItemController(IToDoItemAdminService toDoItemAdminService) : ControllerBase
{
    private readonly IToDoItemAdminService _toDoItemAdminService = toDoItemAdminService;

    [HttpPost]
    public async Task<ActionResult<ToDoItemAdminDataTransferObject?>> Add(ToDoItemAdminDataTransferObject toDoItemAdminDataTransferObject)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var databaseToDoItemAdminDataTransferObject = await _toDoItemAdminService.AddAsync(userName, toDoItemAdminDataTransferObject);

        return Ok(databaseToDoItemAdminDataTransferObject);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ToDoItemAdminDataTransferObject?>> Delete(Guid id)
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
    public async Task<ActionResult<ToDoItemAdminDataTransferObject?>> Edit(Guid id, ToDoItemAdminDataTransferObject toDoItemAdminDataTransferObject)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var databaseToDoItem = await _toDoItemAdminService.EditAsync(userName, id, toDoItemAdminDataTransferObject);

        return Ok(databaseToDoItem);
    }

    [HttpGet]
    public async Task<ActionResult<ToDoItemAdminDataTransferObject>?> GetAll()
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
    public async Task<ActionResult<ToDoItemAdminDataTransferObject?>> GetById(Guid id)
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
