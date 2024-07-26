namespace CarJournal.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(
        this IServiceCollection services)
    {


        return services;
    }

    public static IServiceCollection AddSwagger(
        this IServiceCollection services)
    {
        services.AddSwaggerGen();

        return services;
    }
}