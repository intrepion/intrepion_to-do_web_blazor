﻿using System.Net.Http.Json;
using Intrepion.ToDo.BusinessLogic.Entities;
using Intrepion.ToDo.BusinessLogic.Entities.Dtos;

namespace Intrepion.ToDo.BusinessLogic.Repositories.Client;

public class ApplicationUserClientAdminRepository(HttpClient httpClient) : IApplicationUserAdminRepository
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ApplicationUserAdminDto?> AddAsync(ApplicationUserAdminDto applicationUserAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/applicationUserAdmin", applicationUserAdminDto);

        return await result.Content.ReadFromJsonAsync<ApplicationUserAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/applicationUserAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<ApplicationUserAdminDto?> EditAsync(ApplicationUserAdminDto applicationUserAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/applicationUserAdmin/{applicationUserAdminDto.Id}", applicationUserAdminDto);

        return await result.Content.ReadFromJsonAsync<ApplicationUserAdminDto>();
    }

    public async Task<List<ApplicationUser>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<ApplicationUser>>($"/api/admin/applicationUserAdmin?userName={userName}");

        return result;
    }

    public async Task<ApplicationUserAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<ApplicationUserAdminDto>($"/api/admin/applicationUserAdmin/{id}?userName={userName}");

        return result;
    }
}
