﻿using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class EntityNamePlaceholderClientAdminService(HttpClient httpClient) : IEntityNamePlaceholderAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<EntityNamePlaceholderAdminDataTransferObject?> AddAsync(string userName, EntityNamePlaceholderAdminDataTransferObject toDoListAdminDataTransferObject)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/toDoListAdmin", toDoListAdminDataTransferObject);

        return await result.Content.ReadFromJsonAsync<EntityNamePlaceholderAdminDataTransferObject>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/toDoListAdmin/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<EntityNamePlaceholderAdminDataTransferObject?> EditAsync(string userName, Guid id, EntityNamePlaceholderAdminDataTransferObject toDoListAdminDataTransferObject)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/toDoListAdmin/{id}", toDoListAdminDataTransferObject);

        return await result.Content.ReadFromJsonAsync<EntityNamePlaceholderAdminDataTransferObject>();
    }

    public async Task<List<EntityNamePlaceholderAdminDataTransferObject>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<EntityNamePlaceholderAdminDataTransferObject>>("/api/admin/toDoListAdmin");

        return result;
    }

    public async Task<EntityNamePlaceholderAdminDataTransferObject?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<EntityNamePlaceholderAdminDataTransferObject>($"/api/admin/toDoListAdmin/{id}");

        return result;
    }
}
