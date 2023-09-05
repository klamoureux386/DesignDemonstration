using DesignDemonstration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using DesignDemonstration.Data;
using NSwag.CodeGeneration.TypeScript;
using NSwag;
using System;
using NJsonSchema.CodeGeneration.TypeScript;
using NSwag.CodeGeneration.CSharp;
using DesignDemonstration.Interfaces;
using DesignDemonstration.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();

    // Add OpenAPI 3.0 document serving middleware
    // Available at: http://localhost:<port>/swagger/v1/swagger.json
    app.UseOpenApi();

    // Add web UIs to interact with the document
    // Available at: http://localhost:<port>/swagger
    app.UseSwaggerUi3();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DataContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

void ConfigureServices(IServiceCollection services)
{
    // Add services to the container.
    services.AddControllersWithViews();
    services.AddEndpointsApiExplorer();
    services.AddOpenApiDocument();

    services.AddDatabaseDeveloperPageExceptionFilter();

    // Register the DbContext.
    var folder = Environment.SpecialFolder.LocalApplicationData;
    var path = Environment.GetFolderPath(folder);
    var DbPath = System.IO.Path.Join(path, "music.db");

    builder.Services.AddDbContext<DataContext>(options =>
      options.UseSqlite(builder.Configuration.GetConnectionString($"Data Source={DbPath}")));

    // Register the Swagger services.
    services.AddSwaggerDocument();

    //https://www.c-sharpcorner.com/article/automapper-in-asp-net-core-7-web-api/
    // Register AutoMapper.
    services.AddAutoMapper(typeof(Program));

    //Ignore loops on many-to-many
    services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

    services.AddScoped<IBandsService, BandsService>();
}