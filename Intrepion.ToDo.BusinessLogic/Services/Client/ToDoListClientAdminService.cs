﻿using System.Net.Http.Json;
using Intrepion.ToDo.BusinessLogic.Entities;

namespace Intrepion.ToDo.BusinessLogic.Services.Client;

public class ToDoListClientAdminService(HttpClient httpClient) : IToDoListAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ToDoList?> AddAsync(string userName, ToDoList toDoList)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/ToDoListAdmin", toDoList);

        return await result.Content.ReadFromJsonAsync<ToDoList>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/ToDoListAdmin/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<ToDoList?> EditAsync(string userName, Guid id, ToDoList toDoList)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/ToDoListAdmin/{id}", toDoList);

        return await result.Content.ReadFromJsonAsync<ToDoList>();
    }

    public async Task<List<ToDoList>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ToDoList>>("/api/ToDoListAdmin");

        return result;
    }

    public async Task<ToDoList?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<ToDoList>($"/api/ToDoListAdmin/{id}");

        return result;
    }
}
