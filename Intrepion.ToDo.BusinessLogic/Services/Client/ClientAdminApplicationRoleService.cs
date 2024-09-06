using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class ClientAdminApplicationRoleService(HttpClient httpClient) : IAdminApplicationRoleService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ApplicationRole?> AddAsync(string userName, ApplicationRole applicationRole)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/ApplicationRole", applicationRole);

        return await result.Content.ReadFromJsonAsync<ApplicationRole>();
    }

    public async Task<bool> DeleteAsync(string userName, string id)
    {
        var result = await _httpClient.DeleteAsync($"/api/ApplicationRole/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<ApplicationRole?> EditAsync(string userName, string id, ApplicationRole applicationRole)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/ApplicationRole/{id}", applicationRole);

        return await result.Content.ReadFromJsonAsync<ApplicationRole>();
    }

    public async Task<List<ApplicationRole>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ApplicationRole>>("/api/ApplicationRole");

        return result;
    }

    public async Task<ApplicationRole?> GetByIdAsync(string id)
    {
        var result = await _httpClient.GetFromJsonAsync<ApplicationRole>($"/api/ApplicationRole/{id}");

        return result;
    }
}
