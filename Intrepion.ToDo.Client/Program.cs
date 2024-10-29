using Intrepion.ToDo.BusinessLogic.Repositories.Admin;
using Intrepion.ToDo.BusinessLogic.Repositories.Admin.Client;
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
builder.Services.AddScoped<IApplicationRoleAdminRepository, ApplicationRoleClientAdminRepository>();
builder.Services.AddScoped<IApplicationUserAdminRepository, ApplicationUserClientAdminRepository>();

builder.Services.AddScoped<IToDoItemAdminRepository, ToDoItemClientAdminRepository>();
builder.Services.AddScoped<IToDoListAdminRepository, ToDoListClientAdminRepository>();
// RegisterClientServiceCodePlaceholder

await builder.Build().RunAsync();
