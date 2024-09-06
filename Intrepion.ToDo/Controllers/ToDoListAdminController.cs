using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoListAdminController(IToDoListAdminService toDoListAdminService) : ControllerBase
{
    private readonly IToDoListAdminService _toDoListAdminService = toDoListAdminService;

    [HttpPost]
    public async Task<ActionResult<ToDoList?>> Add(ToDoList toDoList)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedToDoList = await _toDoListAdminService.AddAsync(userName, toDoList);

        return Ok(addedToDoList);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ToDoList?>> Delete(Guid id)
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
    public async Task<ActionResult<ToDoList?>> Edit(Guid id, ToDoList toDoList)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedToDoList = await _toDoListAdminService.EditAsync(userName, id, toDoList);

        return Ok(updatedToDoList);
    }

    [HttpGet]
    public async Task<ActionResult<ToDoList>?> GetAll()
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var toDoLists = await _toDoListAdminService.GetAllAsync();

        return Ok(toDoLists);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoList?>> GetById(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var toDoList = await _toDoListAdminService.GetByIdAsync(id);

        return Ok(toDoList);
    }
}
