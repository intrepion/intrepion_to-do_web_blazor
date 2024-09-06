using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class ToDoItemClientAdminService(HttpClient httpClient) : IToDoItemAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ToDoItem?> AddAsync(string userName, ToDoItem EntityLowercaseNamePlaceholder)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/ToDoItem", EntityLowercaseNamePlaceholder);

        return await result.Content.ReadFromJsonAsync<ToDoItem>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/ToDoItem/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<ToDoItem?> EditAsync(string userName, Guid id, ToDoItem EntityLowercaseNamePlaceholder)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/ToDoItem/{id}", EntityLowercaseNamePlaceholder);

        return await result.Content.ReadFromJsonAsync<ToDoItem>();
    }

    public async Task<List<ToDoItem>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ToDoItem>>("/api/ToDoItem");

        return result;
    }

    public async Task<ToDoItem?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<ToDoItem>($"/api/ToDoItem/{id}");

        return result;
    }
}
