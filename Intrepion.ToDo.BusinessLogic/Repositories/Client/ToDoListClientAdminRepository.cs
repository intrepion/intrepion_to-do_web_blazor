using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Client;

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

    public async Task<List<ToDoList>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<ToDoList>>($"/api/admin/toDoListAdmin?userName={userName}");

        return result;
    }

    public async Task<ToDoListAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<ToDoListAdminDto>($"/api/admin/toDoListAdmin/{id}?userName={userName}");

        return result;
    }
}
