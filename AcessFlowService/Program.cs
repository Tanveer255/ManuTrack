using AcessFlowService.Entity.Data;
using Infrastructure.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using AcessFlowService.Extensions;
using Serilog;
using AcessFlowService.Entity.Common.Model;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AcessFlowServiceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AcessFlowServiceDbContext>()
    .AddDefaultTokenProviders();

#region For Swagger
builder.Services
      .AddSwaggerGen(c =>
      {
          c.AddSecurityDefinition("Bearer", //Name the security scheme
          new OpenApiSecurityScheme
          {
              Description = "JWT Authorization header using the Bearer scheme.",
              Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
              Scheme = "bearer" //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
          });

          c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                 {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer", //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
        });
          c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
      });
# endregion
builder.Services.AddAuthorization();

builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<SendGridSettings>(builder.Configuration.GetSection("SendGridSettings"));
builder.Services.Configure<ReCaptchaSetting>(builder.Configuration.GetSection("ReCaptcha"));
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
// Load Stripe Secret Key
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"]; 

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    #pragma warning disable CS8604 // Possible null reference argument.
    var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
    if (jwtSettings == null)
    {
        throw new InvalidOperationException("JwtSettings configuration is missing.");
    }

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = jwtSettings.Audience,
        ValidIssuer = jwtSettings.Issuer,
        RequireExpirationTime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
        ValidateIssuerSigningKey = true
    };
#pragma warning restore CS8604 // Possible null reference argument.
});

builder.Services.AddAllCustomServices();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // React frontend
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});



//Add support to logging with SERILOG
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();
app.Use(async (context, next) =>
{
    context.Request.EnableBuffering();
    var reader = new StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync();
    context.Request.Body.Position = 0;
    Console.WriteLine($"Request Body: {body}");
    await next();
});


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
app.UseCors("AllowFrontend");
app.Run();
