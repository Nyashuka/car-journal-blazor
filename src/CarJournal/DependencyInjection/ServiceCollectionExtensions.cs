using CarJournal.Infrastructure.Authentication;
using CarJournal.Infrastructure.Persistence;
using CarJournal.Infrastructure.Persistence.Cars;
using CarJournal.Infrastructure.Persistence.Engines;
using CarJournal.Infrastructure.Persistence.Roles;
using CarJournal.Infrastructure.Persistence.Vendors;
using CarJournal.Persistence.Repositories;
using CarJournal.Services;
using CarJournal.Services.Authentication;
using CarJournal.Services.Cars;
using CarJournal.Services.Engines;
using CarJournal.Services.Vendors;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace CarJournal.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(
        this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ProtectedSessionStorage>();
        services.AddScoped<AuthenticationStateProvider, CarJournalAuthenticationStateProvider>();
        services.AddScoped<IClientAuthenticationService, ClientAuthenticationService>();

        services.AddScoped<IAdminVendorService, AdminVendorService>();
        services.AddScoped<IEngineService, EngineService>();

        services.AddScoped<ICarService, CarService>();

        services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
        return services;
    }

    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();

        services.AddScoped<IVendorRepository, VendorRepository>();
        services.AddScoped<IEngineRepository, EngineRepository>();
        services.AddScoped<ICarRepository, CarRepository>();

        services.AddScoped(typeof(IDataRepository<>), typeof(DataRepository<>));
        return services;
    }

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IJwtTokenParser, JwtTokenParser>();

        return services;
    }

    public static IServiceCollection AddSwagger(
        this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static IServiceCollection AddRazor(
            this IServiceCollection services)
    {
        services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/admin/vendors", "admin");
});
        services.AddServerSideBlazor();

        return services;
    }


}