﻿using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class ApplicationUserClientAdminService(HttpClient httpClient) : IApplicationUserAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ApplicationUserAdminDataTransferObject?> AddAsync(string userName, ApplicationUserAdminDataTransferObject applicationUserAdminDataTransferObject)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/applicationUserAdmin", applicationUserAdminDataTransferObject);

        return await result.Content.ReadFromJsonAsync<ApplicationUserAdminDataTransferObject>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/applicationUserAdmin/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<ApplicationUserAdminDataTransferObject?> EditAsync(string userName, Guid id, ApplicationUserAdminDataTransferObject applicationUserAdminDataTransferObject)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/applicationUserAdmin/{id}", applicationUserAdminDataTransferObject);

        return await result.Content.ReadFromJsonAsync<ApplicationUserAdminDataTransferObject>();
    }

    public async Task<List<ApplicationUserAdminDataTransferObject>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ApplicationUserAdminDataTransferObject>>("/api/admin/applicationUserAdmin");

        return result;
    }

    public async Task<ApplicationUserAdminDataTransferObject?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<ApplicationUserAdminDataTransferObject>($"/api/admin/applicationUserAdmin/{id}");

        return result;
    }
}
