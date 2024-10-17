﻿using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Client;

public class EntityNamePlaceholderClientAdminRepository(HttpClient httpClient) : IEntityNamePlaceholderAdminRepository
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<EntityNamePlaceholderAdminDto?> AddAsync(EntityNamePlaceholderAdminDto toDoItemAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/toDoItemAdmin", toDoItemAdminDto);

        return await result.Content.ReadFromJsonAsync<EntityNamePlaceholderAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/toDoItemAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<EntityNamePlaceholderAdminDto?> EditAsync(EntityNamePlaceholderAdminDto toDoItemAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/toDoItemAdmin/{toDoItemAdminDto.Id}", toDoItemAdminDto);

        return await result.Content.ReadFromJsonAsync<EntityNamePlaceholderAdminDto>();
    }

    public async Task<List<EntityNamePlaceholderAdminDto>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<EntityNamePlaceholderAdminDto>>($"/api/admin/toDoItemAdmin?userName={userName}");

        return result;
    }

    public async Task<EntityNamePlaceholderAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<EntityNamePlaceholderAdminDto>($"/api/admin/toDoItemAdmin/{id}?userName={userName}");

        return result;
    }
}
