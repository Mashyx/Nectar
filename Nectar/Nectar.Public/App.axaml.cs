using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Nectar.Public.ViewModels;
using Nectar.Public.Views;
using Nectar.Public.ViewModels;
using Nectar.Public.Views;

namespace Nectar.Public;

public partial class App : Avalonia.Application
{
    private readonly IServiceProvider _services;
    
    public App() { }
    
    public App(IServiceProvider services)
    {
        _services = services;
    }
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = _services.GetRequiredService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}