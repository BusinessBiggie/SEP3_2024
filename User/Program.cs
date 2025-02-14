using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using UserMicroservice.Application.Interfaces;
using UserMicroservice.Application.UseCases;
using UserMicroservice.Application.UseCases.LocationUsecases;
using UserMicroservice.Infrastructure.Persistence.Data;
using UserMicroservice.Infrastructure.Persistence.Repositories;
using UserMicroservice.Interface_adapters.gRPC;

var builder = WebApplication.CreateBuilder(args);

// Konfigurer Kestrel til at lytte på forskellige protokoller og porte
builder.WebHost.ConfigureKestrel(options =>
{
    // HTTPS for gRPC using the development certificate
    options.ListenLocalhost(5117, listenOptions =>
    {
        listenOptions.UseHttps(); // Automatically uses the development certificate
        listenOptions.Protocols = HttpProtocols.Http2;
    });

    // HTTPS for REST API
    options.ListenLocalhost(7200, listenOptions =>
    {
        listenOptions.UseHttps(); // Automatically uses the development certificate
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
    });
});


// Tilføj DbContext med PostgreSQL konfiguration
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UserDatabase")));

// Tilføj gRPC support
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
// Tilføj REST support
builder.Services.AddControllers();

// Registrer repository og services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

// Registrer alle Use Cases (Clean Architecture)
builder.Services.AddScoped<CreateUserUseCase>();
builder.Services.AddScoped<GetUserByEmailUseCase>();
builder.Services.AddScoped<GetUserByIdUseCase>();
builder.Services.AddScoped<DeleteUserUseCase>();
builder.Services.AddScoped<UpdateUserUseCase>();
// Location Use Cases 
builder.Services.AddScoped<CreateLocationForUserUseCase>();
builder.Services.AddScoped<GetLocationByIdUseCase>();
builder.Services.AddScoped<GetAllLocationsUseCase>();
builder.Services.AddScoped<UpdateLocationUseCase>();
builder.Services.AddScoped<DeleteLocationUseCase>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();


// Tilføj Swagger til dokumentation (kun til REST)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Aktiver Swagger i udviklingsmiljøet
if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Microservice API v1");
    });
}

app.Use(async (context, next) =>
{
    Console.WriteLine($"Protocol: {context.Request.Protocol}");
    Console.WriteLine($"Scheme: {context.Request.Scheme}");
    await next();
});

// Middleware-pipeline
app.UseHttpsRedirection(); // Redirect HTTP til HTTPS, hvis nødvendigt
app.UseRouting(); // Konfigurer routing
app.UseAuthorization(); // Tilføj autorisation (hvis det er nødvendigt)

// Registrer gRPC-tjenesten
app.MapGrpcService<GrpcUserService>();

// Registrer REST API Controllers
app.MapControllers();

// Kør applikationen
app.Run();
