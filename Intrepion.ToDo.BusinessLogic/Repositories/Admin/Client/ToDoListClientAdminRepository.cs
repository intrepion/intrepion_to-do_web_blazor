using System.Net.Http.Json;
using Intrepion.ToDo.BusinessLogic.Entities.Dtos.Admin;

namespace Intrepion.ToDo.BusinessLogic.Repositories.Admin.Client;

public class ToDoListClientAdminRepository(HttpClient httpClient) : IToDoListAdminRepository
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ToDoListAdminDto?> AddAsync(ToDoListAdminDto toDoListAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/toDoListAdmin", toDoListAdminDto);

        return await result.Content.ReadFromJsonAsync<ToDoListAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/toDoListAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<ToDoListAdminDto?> EditAsync(ToDoListAdminDto toDoListAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/toDoListAdmin/{toDoListAdminDto.Id}", toDoListAdminDto);

        return await result.Content.ReadFromJsonAsync<ToDoListAdminDto>();
    }

    public async Task<List<ToDoListAdminDto>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<ToDoListAdminDto>>($"/api/admin/toDoListAdmin?userName={userName}");

        return result;
    }

    public async Task<ToDoListAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<ToDoListAdminDto>($"/api/admin/toDoListAdmin/{id}?userName={userName}");

        return result;
    }
}
