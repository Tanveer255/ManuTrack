using Microsoft.EntityFrameworkCore;
using SettingService.Entity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
// Configure logging
builder.Logging.ClearProviders(); // Optional: Clears default providers
builder.Logging.AddConsole();     // Console logging
builder.Logging.AddDebug();       // Debug output
builder.Services.AddDbContext<SettingServiceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = "swagger"; // This will make it accessible at '/swagger'
    });
}
// Example of using ILogger in a request pipeline
app.Use(async (context, next) =>
{
    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Request to {Path}", context.Request.Path);
    await next();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
