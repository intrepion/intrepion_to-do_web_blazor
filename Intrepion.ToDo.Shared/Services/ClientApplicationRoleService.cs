using System.Net.Http.Json;
using Intrepion.ToDo.Shared.Entities;

namespace Intrepion.ToDo.Shared.Services;

public class ClientApplicationRoleService(HttpClient httpClient) : IApplicationRoleService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ApplicationRole> AddAsync(ApplicationRole applicationRole)
    {
        var result = await _httpClient
            .PostAsJsonAsync("/api/applicationRole", applicationRole);

        return await result.Content.ReadFromJsonAsync<ApplicationRole>();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/applicationRole/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<ApplicationRole> EditAsync(Guid id, ApplicationRole applicationRole)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/applicationRole/{id}", applicationRole);

        return await result.Content.ReadFromJsonAsync<ApplicationRole>();
    }

    public Task<List<ApplicationRole>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ApplicationRole> GetByIdAsync(Guid id)
    {
        var result = await _httpClient
            .GetFromJsonAsync<ApplicationRole>($"/api/applicationRole/{id}");

        return result;
    }
}
