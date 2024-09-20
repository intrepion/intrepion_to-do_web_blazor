using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class ToDoListController(IToDoListAdminService toDoListAdminService) : ControllerBase
{
    private readonly IToDoListAdminService _toDoListAdminService = toDoListAdminService;

    [HttpPost]
    public async Task<ActionResult<ToDoListAdminDataTransferObject?>> Add(ToDoListAdminDataTransferObject toDoListAdminDataTransferObject)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var databaseToDoListAdminDataTransferObject = await _toDoListAdminService.AddAsync(userName, toDoListAdminDataTransferObject);

        return Ok(databaseToDoListAdminDataTransferObject);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ToDoListAdminDataTransferObject?>> Delete(Guid id)
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
    public async Task<ActionResult<ToDoListAdminDataTransferObject?>> Edit(Guid id, ToDoListAdminDataTransferObject toDoListAdminDataTransferObject)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var databaseToDoList = await _toDoListAdminService.EditAsync(userName, id, toDoListAdminDataTransferObject);

        return Ok(databaseToDoList);
    }

    [HttpGet]
    public async Task<ActionResult<ToDoListAdminDataTransferObject>?> GetAll()
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
    public async Task<ActionResult<ToDoListAdminDataTransferObject?>> GetById(Guid id)
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
