using BlazorApp1.Client.Service;
using Blog.Application.Service;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7136") });

builder.Services.AddScoped<IPostService, PostServiceHttpClient>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
