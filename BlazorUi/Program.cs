using System.Reflection;
using BlazorUi.Components;
using DemoLibrary.DataAccess;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

Assembly[] mediatRAssemblies =
[
    typeof(DemoDataAccess).Assembly
];

services
    .AddSingleton<IDataAccess, DemoDataAccess>()
    .AddMediatR(mediatRServiceConfig => mediatRServiceConfig.RegisterServicesFromAssemblies(mediatRAssemblies));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
