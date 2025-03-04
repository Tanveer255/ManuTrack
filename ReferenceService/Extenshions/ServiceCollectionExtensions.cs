using Microsoft.AspNetCore.Mvc.Infrastructure;
using ReferenceService.Repository;
using ReferenceService.Service;

namespace ReferenceService.Extenshions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllCustomServices(this IServiceCollection services)
    {
        services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
        services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
        services.AddScoped<ICountryService, CountryService>();
       

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICountryRepository, CountryRepository>();

        return services;
    }
}
