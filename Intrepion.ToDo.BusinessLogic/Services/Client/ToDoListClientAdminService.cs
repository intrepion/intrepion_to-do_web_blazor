using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class ToDoListClientAdminService(HttpClient httpClient) : IToDoListAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ToDoList?> AddAsync(string userName, ToDoList EntityLowercaseNamePlaceholder)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/ToDoList", EntityLowercaseNamePlaceholder);

        return await result.Content.ReadFromJsonAsync<ToDoList>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/ToDoList/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<ToDoList?> EditAsync(string userName, Guid id, ToDoList EntityLowercaseNamePlaceholder)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/ToDoList/{id}", EntityLowercaseNamePlaceholder);

        return await result.Content.ReadFromJsonAsync<ToDoList>();
    }

    public async Task<List<ToDoList>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ToDoList>>("/api/ToDoList");

        return result;
    }

    public async Task<ToDoList?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<ToDoList>($"/api/ToDoList/{id}");

        return result;
    }
}
