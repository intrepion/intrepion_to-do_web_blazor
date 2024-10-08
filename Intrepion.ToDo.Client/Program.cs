﻿using Intrepion.ToDo.BusinessLogic.Services;
using Intrepion.ToDo.BusinessLogic.Services.Client;
using Intrepion.ToDo.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});
builder.Services.AddScoped<IApplicationRoleAdminService, ApplicationRoleClientAdminService>();
builder.Services.AddScoped<IApplicationUserAdminService, ApplicationUserClientAdminService>();

builder.Services.AddScoped<IToDoItemAdminService, ToDoItemClientAdminService>();
builder.Services.AddScoped<IToDoListAdminService, ToDoListClientAdminService>();
// RegisterClientServiceCodePlaceholder

await builder.Build().RunAsync();
