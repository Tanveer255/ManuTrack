using Infrastructure.Service;

namespace AcessFlowService.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllCustomServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IManageUserRolesService, ManageUserRolesService>();
        //services.AddScoped<IUserRolesService, IUserRolesService>();
        services.AddScoped<IUserRolesService, UserRolesService>();
        services.AddTransient<IApplicationUserService, ApplicationUserService>();
        services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
        services.AddSingleton<IInfrastructureService, InfrastructureService>();

        // Change ICompanyService to scoped
        services.AddScoped<ICompanyService, CompanyService>();

        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IManageUserRolesRepository, ManageUserRolesRepository>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRolesRepository, UserRolesRepository>();
        services.AddTransient<IApplicationUserRepository, ApplicationUserRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();

        return services;
    }
}
