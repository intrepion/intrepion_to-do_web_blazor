using AppNamePlaceholder.Client;
using AppNamePlaceholder.Shared.Services.Client;
using AppNamePlaceholder.Shared.Services.Interfaces;
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

builder.Services.AddScoped<IApplicationRoleService, ClientApplicationRoleService>();
builder.Services.AddScoped<IApplicationUserService, ClientApplicationUserService>();

await builder.Build().RunAsync();
