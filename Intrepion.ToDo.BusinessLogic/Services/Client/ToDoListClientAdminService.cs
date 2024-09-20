using System.Net.Http.Json;
using Intrepion.ToDo.BusinessLogic.Entities.DataTransferObjects;

namespace Intrepion.ToDo.BusinessLogic.Services.Client;

public class ToDoListClientAdminService(HttpClient httpClient) : IToDoListAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ToDoListAdminDataTransferObject?> AddAsync(string userName, ToDoListAdminDataTransferObject toDoListAdminDataTransferObject)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/toDoListAdmin", toDoListAdminDataTransferObject);

        return await result.Content.ReadFromJsonAsync<ToDoListAdminDataTransferObject>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/toDoListAdmin/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<ToDoListAdminDataTransferObject?> EditAsync(string userName, Guid id, ToDoListAdminDataTransferObject toDoListAdminDataTransferObject)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/toDoListAdmin/{id}", toDoListAdminDataTransferObject);

        return await result.Content.ReadFromJsonAsync<ToDoListAdminDataTransferObject>();
    }

    public async Task<List<ToDoListAdminDataTransferObject>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ToDoListAdminDataTransferObject>>("/api/admin/toDoListAdmin");

        return result;
    }

    public async Task<ToDoListAdminDataTransferObject?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<ToDoListAdminDataTransferObject>($"/api/admin/toDoListAdmin/{id}");

        return result;
    }
}
