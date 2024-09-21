using Intrepion.ToDo.BusinessLogic.Entities.Dtos;
using Intrepion.ToDo.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Intrepion.ToDo.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class ToDoItemController(IToDoItemAdminService toDoItemAdminService) : ControllerBase
{
    private readonly IToDoItemAdminService _toDoItemAdminService = toDoItemAdminService;

    [HttpPost]
    public async Task<ActionResult<ToDoItemAdminDto?>> Add(ToDoItemAdminDto toDoItemAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(toDoItemAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseToDoItemAdminDto = await _toDoItemAdminService.AddAsync(toDoItemAdminDto);

        return Ok(databaseToDoItemAdminDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool?>> Delete(string userName, Guid id)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(userName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var result = await _toDoItemAdminService.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<ToDoItemAdminDto?>> Edit(ToDoItemAdminDto toDoItemAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(toDoItemAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseToDoItem = await _toDoItemAdminService.EditAsync(toDoItemAdminDto);

        return Ok(databaseToDoItem);
    }

    [HttpGet]
    public async Task<ActionResult<ToDoItemAdminDto>?> GetAll(string userName)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(userName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var toDoItemAdminDtos = await _toDoItemAdminService.GetAllAsync(userIdentityName);

        return Ok(toDoItemAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItemAdminDto?>> GetById(string userName, Guid id)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(userName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var toDoItemAdminDto = await _toDoItemAdminService.GetByIdAsync(userIdentityName, id);

        return Ok(toDoItemAdminDto);
    }
}
