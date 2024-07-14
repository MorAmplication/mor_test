using Kkk.APIs;

namespace Kkk;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IMorsService, MorsService>();
        services.AddScoped<INnsService, NnsService>();
    }
}
