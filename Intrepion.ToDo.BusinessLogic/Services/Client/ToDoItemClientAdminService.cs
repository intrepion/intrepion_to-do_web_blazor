using System.Net.Http.Json;
using Intrepion.ToDo.BusinessLogic.Entities;

namespace Intrepion.ToDo.BusinessLogic.Services.Client;

public class ToDoItemClientAdminService(HttpClient httpClient) : IToDoItemAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ToDoItem?> AddAsync(string userName, ToDoItem toDoItem)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/ToDoItemAdmin", toDoItem);

        return await result.Content.ReadFromJsonAsync<ToDoItem>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/ToDoItemAdmin/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<ToDoItem?> EditAsync(string userName, Guid id, ToDoItem toDoItem)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/ToDoItemAdmin/{id}", toDoItem);

        return await result.Content.ReadFromJsonAsync<ToDoItem>();
    }

    public async Task<List<ToDoItem>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ToDoItem>>("/api/ToDoItemAdmin");

        return result;
    }

    public async Task<ToDoItem?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<ToDoItem>($"/api/ToDoItemAdmin/{id}");

        return result;
    }
}
