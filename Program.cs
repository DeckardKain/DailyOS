using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using DailyOS;
using DailyOS.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var supabaseUrl = builder.Configuration["Supabase:Url"] ?? "";
var supabaseKey = builder.Configuration["Supabase:AnonKey"] ?? "";

builder.Services.AddScoped(sp =>
{
    var client = new HttpClient { BaseAddress = new Uri(supabaseUrl) };
    client.DefaultRequestHeaders.Add("apikey", supabaseKey);
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {supabaseKey}");
    return client;
});

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AppStateService>();
builder.Services.AddScoped<SupabaseService>();

await builder.Build().RunAsync();
