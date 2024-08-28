using System.Net.Http.Json;
using AppNamePlaceholder.Shared.Entities;
using AppNamePlaceholder.Shared.Services.Interfaces;

namespace AppNamePlaceholder.Shared.Services.Client;

public class ClientApplicationRoleService(HttpClient httpClient) : IApplicationRoleService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ApplicationRole> AddAsync(string userName, ApplicationRole applicationRole)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/applicationRole", applicationRole);

        return await result.Content.ReadFromJsonAsync<ApplicationRole>();
    }

    public async Task<bool> DeleteAsync(string userName, string id)
    {
        var result = await _httpClient.DeleteAsync($"/api/applicationRole/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<ApplicationRole> EditAsync(string userName, string id, ApplicationRole applicationRole)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/applicationRole/{id}", applicationRole);

        return await result.Content.ReadFromJsonAsync<ApplicationRole>();
    }

    public async Task<List<ApplicationRole>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ApplicationRole>>("/api/applicationRole");

        return result;
    }

    public async Task<ApplicationRole> GetByIdAsync(string id)
    {
        var result = await _httpClient.GetFromJsonAsync<ApplicationRole>($"/api/applicationRole/{id}");

        return result;
    }
}
