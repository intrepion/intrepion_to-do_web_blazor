using Intrepion.ToDo.Shared.Entities;
using Intrepion.ToDo.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Intrepion.ToDo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationUserController(IApplicationUserService applicationUserService) : ControllerBase
{
    private readonly IApplicationUserService _applicationUserService = applicationUserService;

    [HttpPost]
    public async Task<ActionResult<ApplicationUser>> Add(ApplicationUser applicationUser)
    {
        var addedGame = await _applicationUserService.AddAsync(applicationUser);

        return Ok(addedGame);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApplicationUser>> Delete(string id)
    {
        var result = await _applicationUserService.DeleteAsync(id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApplicationUser>> Edit(string id, ApplicationUser applicationUser)
    {
        var updatedGame = await _applicationUserService.EditAsync(id, applicationUser);

        return Ok(updatedGame);
    }

    [HttpGet]
    public async Task<ActionResult<ApplicationUser>> GetAll()
    {
        var games = await _applicationUserService.GetAllAsync();

        return Ok(games);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationUser>> GetById(string id)
    {
        var game = await _applicationUserService.GetByIdAsync(id);

        return Ok(game);
    }
}
