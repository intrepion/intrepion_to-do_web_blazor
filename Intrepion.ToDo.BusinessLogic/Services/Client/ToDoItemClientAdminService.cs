using System.Net.Http.Json;
using Intrepion.ToDo.BusinessLogic.Entities;
using Intrepion.ToDo.BusinessLogic.Entities.Dtos;

namespace Intrepion.ToDo.BusinessLogic.Services.Client;

public class ToDoItemClientAdminService(HttpClient httpClient) : IToDoItemAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ToDoItemAdminDto?> AddAsync(ToDoItemAdminDto toDoItemAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/toDoItemAdmin", toDoItemAdminDto);

        return await result.Content.ReadFromJsonAsync<ToDoItemAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/toDoItemAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<ToDoItemAdminDto?> EditAsync(ToDoItemAdminDto toDoItemAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/toDoItemAdmin/{toDoItemAdminDto.Id}", toDoItemAdminDto);

        return await result.Content.ReadFromJsonAsync<ToDoItemAdminDto>();
    }

    public async Task<List<ToDoItem>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<ToDoItem>>($"/api/admin/toDoItemAdmin?userName={userName}");

        return result;
    }

    public async Task<ToDoItemAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<ToDoItemAdminDto>($"/api/admin/toDoItemAdmin/{id}?userName={userName}");

        return result;
    }
}
