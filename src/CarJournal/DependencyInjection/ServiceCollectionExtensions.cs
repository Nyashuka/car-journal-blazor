using CarJournal.Infrastructure.Authentication;
using CarJournal.Infrastructure.Persistence;
using CarJournal.Infrastructure.Persistence.Cars;
using CarJournal.Infrastructure.Persistence.Engines;
using CarJournal.Infrastructure.Persistence.MileageRecords;
using CarJournal.Infrastructure.Persistence.Roles;
using CarJournal.Infrastructure.Persistence.ServiceCategories;
using CarJournal.Infrastructure.Persistence.ServiceRecords;
using CarJournal.Infrastructure.Persistence.Trackings;
using CarJournal.Infrastructure.Persistence.UserCars;
using CarJournal.Infrastructure.Persistence.Vendors;
using CarJournal.Mappings;
using CarJournal.Persistence.Repositories;
using CarJournal.Services;
using CarJournal.Services.Authentication;
using CarJournal.Services.Cars;
using CarJournal.Services.Client;
using CarJournal.Services.Engines;
using CarJournal.Services.Mileages;
using CarJournal.Services.ServiceCategories;
using CarJournal.Services.ServiceRecords;
using CarJournal.Services.Trackings;
using CarJournal.Services.UserCars;
using CarJournal.Services.Vendors;

using Hangfire;
using Hangfire.MemoryStorage;

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
        services.AddScoped<IUserCarsService, UserCarsService>();
        services.AddScoped<IMileageService, MileageService>();
        services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
        services.AddScoped<IServiceRecordService, ServiceRecordService>();

        services.AddScoped<ISelectedCarService, SelectedCarService>();
        services.AddScoped<ITrackingService, TrackingService>();


        services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

        services.AddHangfire(config =>
            config.UseMemoryStorage());

        services.AddHangfireServer();

        services.AddAutoMapper(typeof(MappingProfile));

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
        services.AddScoped<IUserCarsRepository, UserCarsRepository>();
        services.AddScoped<IMileageRepository, MileageRepository>();
        services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();
        services.AddScoped<IServiceRecordRepository, ServiceRecordRepository>();
        services.AddScoped<ITrackingsRepository, TrackingsRepository>();

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
        services.AddRazorPages();
        services.AddServerSideBlazor();

        return services;
    }


}