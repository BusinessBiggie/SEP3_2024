using EcoUme.Components;
using EcoUme.Services;
using Smart.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSmart();

// Register HttpClient with base address pointing to ListingsService
builder.Services.AddHttpClient<IListingsService, HttpListingsService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:7202/");
});

builder.Services.AddHttpClient<IUsersService, HttpUsersService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:7200/");
});

builder.Services.AddHttpClient<IChatService, HttpChatService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5230/api/"); // Ensure HTTPS
});

builder.Services.AddScoped<TokenStorageService>();

builder.Services.AddScoped<SignalRService>(sp =>
{
    var tokenStorage = sp.GetRequiredService<TokenStorageService>();
    var hubUrl = "http://localhost:5230/chatHub";
    return new SignalRService(hubUrl, tokenStorage);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
