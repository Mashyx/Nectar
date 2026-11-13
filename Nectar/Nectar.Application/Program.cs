using Avalonia;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nectar.Integrations.Steam;
using Nectar.Public;
using Nectar.Public.ViewModels;
using Nectar.Public.Views;

namespace Nectar.Application;

public sealed class Program
{
    private static IServiceProvider? _services;

    [STAThread]
    public static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        ServiceCollection services = new();
        services.AddSteamIntegration(configuration.GetSection("SteamSettings").Bind);
        services.AddViewModels();

        _services = services.BuildServiceProvider();
        
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>(() => new App(_services))
            .UsePlatformDetect()
            .LogToTrace();
}
