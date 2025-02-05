using AcessFlow.BLL.Interfaces;
using AcessFlow.DAL.Interface;
using AcessFlow.Entity.Data;
using AcessFlow.Entity.Entity.Identity;
using EBS.DAL.Interface;
using EBS.DAL.Repository;
using AcessFlow.BLL.Services;
using JwtAuthentication.Interface;
using JwtAuthentication.Model;
using JwtAuthentication.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using AcessFlow;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AcessFlowDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AcessFlowDbContext>()
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

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

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
