using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.AddConsole();
// Add Ocelot configuration
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
// Add Ocelot services
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader().
               WithOrigins("http://localhost:60118");
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
// Use CORS
app.UseCors("AllowAllOrigins");

// Configure Ocelot middleware
app.UseOcelot().Wait();
//app.Use(async (context, next) =>
//{
//    if (context.Request.Method == HttpMethods.Options)
//    {
//        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
//        context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
//        context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
//        context.Response.StatusCode = (int)HttpStatusCode.OK;
//        await context.Response.CompleteAsync();
//    }
//    else
//    {
//        await next();
//    }
//});



app.Run();
