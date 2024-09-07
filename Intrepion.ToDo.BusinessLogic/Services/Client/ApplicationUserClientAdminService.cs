using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class ApplicationUserClientAdminService(HttpClient httpClient) : IApplicationUserAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ApplicationUser?> AddAsync(string userName, ApplicationUser applicationUser)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/ApplicationUser", applicationUser);

        return await result.Content.ReadFromJsonAsync<ApplicationUser>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/ApplicationUser/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<ApplicationUser?> EditAsync(string userName, Guid id, ApplicationUser applicationUser)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/ApplicationUser/{id}", applicationUser);

        return await result.Content.ReadFromJsonAsync<ApplicationUser>();
    }

    public async Task<List<ApplicationUser>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ApplicationUser>>("/api/ApplicationUser");

        return result;
    }

    public async Task<ApplicationUser?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<ApplicationUser>($"/api/ApplicationUser/{id}");

        return result;
    }
}
