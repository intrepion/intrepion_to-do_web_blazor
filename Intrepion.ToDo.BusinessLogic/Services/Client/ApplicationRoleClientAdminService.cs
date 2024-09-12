using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class ApplicationRoleClientAdminService(HttpClient httpClient) : IApplicationRoleAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ApplicationRoleAdminDataTransferObject?> AddAsync(string userName, ApplicationRoleAdminDataTransferObject applicationRoleAdminDataTransferObject)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/applicationRoleAdmin", applicationRoleAdminDataTransferObject);

        return await result.Content.ReadFromJsonAsync<ApplicationRoleAdminDataTransferObject>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/applicationRoleAdmin/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<ApplicationRoleAdminDataTransferObject?> EditAsync(string userName, Guid id, ApplicationRoleAdminDataTransferObject applicationRoleAdminDataTransferObject)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/applicationRoleAdmin/{id}", applicationRoleAdminDataTransferObject);

        return await result.Content.ReadFromJsonAsync<ApplicationRoleAdminDataTransferObject>();
    }

    public async Task<List<ApplicationRoleAdminDataTransferObject>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ApplicationRoleAdminDataTransferObject>>("/api/applicationRoleAdmin");

        return result;
    }

    public async Task<ApplicationRoleAdminDataTransferObject?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<ApplicationRoleAdminDataTransferObject>($"/api/applicationRoleAdmin/{id}");

        return result;
    }
}
