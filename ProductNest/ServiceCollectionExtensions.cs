using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ProductNest.BLL.Interface;
using ProductNest.BLL.Interface.Manufacturing;
using ProductNest.BLL.Service;
using ProductNest.BLL.Service.Manufacturing;
using ProductNest.DAL.Interface;
using ProductNest.DAL.Interface.Manufacturing;
using ProductNest.DAL.Repository;
using ProductNest.DAL.Repository.Manufacturing;

namespace ProductNest;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllCustomServices(this IServiceCollection services)
    {

        services.AddScoped<IBatchService, BatchService>();
        services.AddScoped<ICompletedPartService, CompletedPartService>();
        services.AddScoped<IImpactedComponentService, ImpactedComponentService>();
        services.AddScoped<IBOMItemService, BOMItemService>();
        services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
        services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
        services.AddScoped<IImageFileService, ImageFileService>();
        services.AddScoped<IInventoryService, InventoryService>();
        services.AddScoped<IPresentmentPriceService, PresentmentPriceService>();
        services.AddScoped<IPriceService, PriceService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IVariantOptionService, VariantOptionService>();
        services.AddScoped<IVariantService, VariantService>();
        services.AddScoped<IWarehouseService, WarehouseService>();


        services.AddScoped<IBatchRepository, BatchRepository>();
        services.AddScoped<ICompletedPartRepository, CompletedPartRepository>();
        services.AddScoped<IImpactedComponentRepository, ImpactedComponentRepository>();
        services.AddScoped<IBOMItemRepository, BOMItemRepository>();
        services.AddScoped<IImageFileRepository, ImageFileRepository>();
        services.AddScoped<IInventoryRepository, InventoryRepository>();
        services.AddScoped<IPresentmentPriceRepository, PresentmentPriceRepository>();
        services.AddScoped<IPriceRepository, PriceRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfMeasureRepository, UnitOfMeasureRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IVariantOptionRepository, VariantOptionRepository>();
        services.AddScoped<IVariantRepository, VariantRepository>();
        services.AddScoped<IWarehouseRepository, WarehouseRepository>();

        return services;
    }
}
