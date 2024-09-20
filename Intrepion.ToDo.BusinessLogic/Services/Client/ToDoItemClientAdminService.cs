using System.Net.Http.Json;
using Intrepion.ToDo.BusinessLogic.Entities.DataTransferObjects;

namespace Intrepion.ToDo.BusinessLogic.Services.Client;

public class ToDoItemClientAdminService(HttpClient httpClient) : IToDoItemAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ToDoItemAdminDataTransferObject?> AddAsync(string userName, ToDoItemAdminDataTransferObject toDoItemAdminDataTransferObject)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/toDoItemAdmin", toDoItemAdminDataTransferObject);

        return await result.Content.ReadFromJsonAsync<ToDoItemAdminDataTransferObject>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/toDoItemAdmin/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<ToDoItemAdminDataTransferObject?> EditAsync(string userName, Guid id, ToDoItemAdminDataTransferObject toDoItemAdminDataTransferObject)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/toDoItemAdmin/{id}", toDoItemAdminDataTransferObject);

        return await result.Content.ReadFromJsonAsync<ToDoItemAdminDataTransferObject>();
    }

    public async Task<List<ToDoItemAdminDataTransferObject>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ToDoItemAdminDataTransferObject>>("/api/admin/toDoItemAdmin");

        return result;
    }

    public async Task<ToDoItemAdminDataTransferObject?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<ToDoItemAdminDataTransferObject>($"/api/admin/toDoItemAdmin/{id}");

        return result;
    }
}
