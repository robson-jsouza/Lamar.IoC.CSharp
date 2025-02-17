using Lamar.IoC.DLL.Registry;
using Lamar.IoC.DLL.Services;
using Lamar.IoC.DLL.Services.Interfaces;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Win32;

var builder = WebApplication.CreateBuilder(args);

// Use Lamar as DI container
builder.Host.UseLamar((context, services) =>
{
    // Add framework services
    services.AddControllers();

    // ✅ Register Swagger manually
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    });

    //services.AddScoped<IScopedService, ScopedService>(); // This also works but it is easier to set MyRegistry class as in the line below
    services.IncludeRegistry<MyRegistry>(); // Add your custom registry

    // Register dependencies using Lamar's syntax
    services.Scan(scan =>
    {
        scan.TheCallingAssembly();
        scan.WithDefaultConventions();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
