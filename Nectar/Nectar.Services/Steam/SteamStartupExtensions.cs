using Microsoft.Extensions.DependencyInjection;
using Nectar.Integrations.Steam.API;
using Nectar.Services.Steam.API;

namespace Nectar.Integrations.Steam;

public static class SteamStartupExtensions
{
    public static IServiceCollection AddSteamIntegration(
        this IServiceCollection services, 
        Action<SteamSettings> configureOptions)
    {

        services.Configure<SteamSettings>(configureOptions);
        services.AddTransient<ISteamApi, SteamApiService>();
        return services;
    }
}