using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class EntityNamePlaceholderClientAdminService(HttpClient httpClient) : IEntityNamePlaceholderAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<EntityNamePlaceholder?> AddAsync(string userName, EntityNamePlaceholder EntityLowercaseNamePlaceholder)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/EntityNamePlaceholderAdmin", EntityLowercaseNamePlaceholder);

        return await result.Content.ReadFromJsonAsync<EntityNamePlaceholder>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/EntityNamePlaceholderAdmin/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<EntityNamePlaceholder?> EditAsync(string userName, Guid id, EntityNamePlaceholder EntityLowercaseNamePlaceholder)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/EntityNamePlaceholderAdmin/{id}", EntityLowercaseNamePlaceholder);

        return await result.Content.ReadFromJsonAsync<EntityNamePlaceholder>();
    }

    public async Task<List<EntityNamePlaceholder>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<EntityNamePlaceholder>>("/api/EntityNamePlaceholderAdmin");

        return result;
    }

    public async Task<EntityNamePlaceholder?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<EntityNamePlaceholder>($"/api/EntityNamePlaceholderAdmin/{id}");

        return result;
    }
}
