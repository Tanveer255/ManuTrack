using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ProductNest.BLL.Interface;
using ProductNest.BLL.Service;
using ProductNest.DAL.Interface;
using ProductNest.DAL.Repository;

namespace ProductNest;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllCustomServices(this IServiceCollection services)
    {

        services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
        services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
        services.AddScoped<IProductService, ProductService>();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProductRepository, ProductRepository>();


        return services;
    }
}
