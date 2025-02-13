using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//// Configure logging
builder.Logging.ClearProviders(); // Optional: Clears default providers
builder.Logging.AddConsole();     // Console logging
builder.Logging.AddDebug();       // Debug output


// Configure Serilog
//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Console()
//    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
//    .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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
