using Microsoft.Extensions.DependencyInjection;
using Nectar.Public.ViewModels;

namespace Nectar.Public;

public static class UiStartupExtensions
{
    public static IServiceCollection AddViewModels(
        this IServiceCollection services)
    {
        services.AddTransient<MainViewModel>();
        services.AddTransient<HomeViewModel>();
        services.AddTransient<BingoViewModel>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<LibraryViewModel>();
        return services;
    }
}