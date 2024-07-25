using DotnetService.APIs;

namespace DotnetService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IMorsService, MorsService>();
        services.AddScoped<IVikasService, VikasService>();
    }
}
