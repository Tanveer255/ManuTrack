using AcessFlowService.BLL.Services;
using JwtAuthentication.Service;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AcessFlowService.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllCustomServices(this IServiceCollection services)
    {
        services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
        services.AddTransient<IApplicationUserService, ApplicationUserService>();
        services.AddTransient<IApplicationUserRepository, ApplicationUserRepository>();
        services.AddSingleton<IJwtAuthenticationService, JwtAuthenticationService>();
        // Register Email Service
        services.AddScoped<IEmailService, EmailService>();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));

        return services;
    }
}
