using System.Net.Http.Json;
using Intrepion.ToDo.BusinessLogic.Entities.DataTransferObjects;

namespace Intrepion.ToDo.BusinessLogic.Services.Client;

public class ClientApplicationUserService(HttpClient httpClient) : IApplicationUserService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<AdminApplicationUserEditDataTransferObject> AddAsync(string userName, AdminApplicationUserEditDataTransferObject applicationUser)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/applicationUser", applicationUser);

        var adminApplicationUserEditDataTransferObject = await result.Content.ReadFromJsonAsync<AdminApplicationUserEditDataTransferObject>();

        if (adminApplicationUserEditDataTransferObject == null)
        {
            return new AdminApplicationUserEditDataTransferObject();
        }

        return adminApplicationUserEditDataTransferObject;
    }

    public async Task<bool> DeleteAsync(string userName, string id)
    {
        var result = await _httpClient.DeleteAsync($"/api/applicationUser/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<AdminApplicationUserEditDataTransferObject> EditAsync(string userName, string id, AdminApplicationUserEditDataTransferObject applicationUser)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/applicationUser/{id}", applicationUser);

        var adminApplicationUserEditDataTransferObject = await result.Content.ReadFromJsonAsync<AdminApplicationUserEditDataTransferObject>();

        if (adminApplicationUserEditDataTransferObject == null)
        {
            return new AdminApplicationUserEditDataTransferObject();
        }

        return adminApplicationUserEditDataTransferObject;
    }

    public async Task<List<AdminApplicationUserListItemDataTransferObject>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<AdminApplicationUserListItemDataTransferObject>>("/api/applicationUser");

        if (result == null)
        {
            return new List<AdminApplicationUserListItemDataTransferObject>();
        }

        return result;
    }

    public async Task<AdminApplicationUserEditDataTransferObject> GetByIdAsync(string id)
    {
        var result = await _httpClient.GetFromJsonAsync<AdminApplicationUserEditDataTransferObject>($"/api/applicationUser/{id}");

        if (result == null)
        {
            return new AdminApplicationUserEditDataTransferObject();
        }

        return result;
    }
}
