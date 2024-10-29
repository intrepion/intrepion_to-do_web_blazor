using Intrepion.ToDo.BusinessLogic.Entities.Dtos.Admin;
using Intrepion.ToDo.BusinessLogic.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Intrepion.ToDo.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class ToDoListController(IToDoListAdminRepository toDoListAdminRepository) : ControllerBase
{
    private readonly IToDoListAdminRepository _toDoListAdminRepository = toDoListAdminRepository;

    [HttpPost]
    public async Task<ActionResult<ToDoListAdminDto?>> Add(ToDoListAdminDto toDoListAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(toDoListAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseToDoListAdminDto = await _toDoListAdminRepository.AddAsync(toDoListAdminDto);

        return Ok(databaseToDoListAdminDto);
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

        var result = await _toDoListAdminRepository.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<ToDoListAdminDto?>> Edit(ToDoListAdminDto toDoListAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(toDoListAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseToDoList = await _toDoListAdminRepository.EditAsync(toDoListAdminDto);

        return Ok(databaseToDoList);
    }

    [HttpGet]
    public async Task<ActionResult<ToDoListAdminDto>?> GetAll(string userName)
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

        var toDoListAdminDtos = await _toDoListAdminRepository.GetAllAsync(userIdentityName);

        return Ok(toDoListAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoListAdminDto?>> GetById(string userName, Guid id)
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

        var toDoListAdminDto = await _toDoListAdminRepository.GetByIdAsync(userIdentityName, id);

        return Ok(toDoListAdminDto);
    }
}
