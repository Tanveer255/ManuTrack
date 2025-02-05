using AcessFlow.BLL.Services;
using AcessFlow.DAL.Interface;
using AcessFlow.DAL.Repository;
using EBS.DAL.Interface;
using EBS.DAL.Repository;
using JwtAuthentication.Service;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AcessFlow;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllCustomServices(this IServiceCollection services)
    {
        services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
        services.AddTransient<IApplicationUserService, ApplicationUserService>();
        services.AddTransient<IApplicationUserRepository,ApplicationUserRepository>();
        services.AddSingleton<IJwtAuthenticationService, JwtAuthenticationService>();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));

        return services;
    }
}
