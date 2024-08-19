using CarJournal.Infrastructure.Authentication;
using CarJournal.Infrastructure.Persistence.Roles;
using CarJournal.Persistence.Repositories;
using CarJournal.Services.Authentication;

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

        return services;
    }

    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();

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
        services.AddRazorPages();
        services.AddServerSideBlazor();

        return services;
    }


}