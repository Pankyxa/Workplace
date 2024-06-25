using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Workplace.Client;
using Workplace.Client.Data;
using Workplace.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Workplace.Client.Data.Schedule;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IDataService, MockData>();
builder.Services.AddSingleton<IScheduleDataService, ScheduleMockData>();

builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());

await builder.Build().RunAsync();