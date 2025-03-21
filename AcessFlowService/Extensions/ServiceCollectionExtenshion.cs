﻿namespace AcessFlowService.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllCustomServices(this IServiceCollection services)
    {
        //services.AddSingleton<ICompanyService, CompanyService>();
        services.AddScoped<AcessFlowService.Services.ICompanyService, AcessFlowService.Services.CompanyService>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IManageUserRolesService, ManageUserRolesService>();
        //services.AddScoped<IUserRolesService, IUserRolesService>();
        services.AddScoped<IUserRolesService, UserRolesService>();
        services.AddTransient<IApplicationUserService, ApplicationUserService>();
        services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
        services.AddSingleton<IJwtAuthenticationService, JwtAuthenticationService>();

        services.AddTransient<IApplicationUserRepository, ApplicationUserRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IManageUserRolesRepository, ManageUserRolesRepository>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRolesRepository, UserRolesRepository>();

        return services;
    }
}
