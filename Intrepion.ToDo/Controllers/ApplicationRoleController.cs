using Intrepion.ToDo.Shared.Entities;
using Intrepion.ToDo.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Intrepion.ToDo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationRoleController(IApplicationRoleService applicationRoleService) : ControllerBase
{
    private readonly IApplicationRoleService _applicationRoleService = applicationRoleService;

    [HttpPost]
    public async Task<ActionResult<ApplicationRole>> Add(ApplicationRole applicationRole)
    {
        var addedGame = await _applicationRoleService.AddAsync(applicationRole);

        return Ok(addedGame);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApplicationRole>> Delete(string id)
    {
        var result = await _applicationRoleService.DeleteAsync(id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApplicationRole>> Edit(string id, ApplicationRole applicationRole)
    {
        var updatedGame = await _applicationRoleService.EditAsync(id, applicationRole);

        return Ok(updatedGame);
    }

    [HttpGet]
    public async Task<ActionResult<ApplicationRole>> GetAll()
    {
        var games = await _applicationRoleService.GetAllAsync();

        return Ok(games);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationRole>> GetById(string id)
    {
        var game = await _applicationRoleService.GetByIdAsync(id);

        return Ok(game);
    }
}
