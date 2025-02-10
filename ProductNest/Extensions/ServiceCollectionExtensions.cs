namespace ProductNest.Extensions;

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
        services.AddScoped<IUnitOfMeasureService, UnitOfMeasureService>();
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
