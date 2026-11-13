using System.Collections.ObjectModel;
using Avalonia.Layout;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Nectar.Integrations.Steam.API;
using Nectar.Public.Models;
using Nectar.Public.Views;

namespace Nectar.Public.ViewModels;

public partial class MainViewModel : ViewModelBase<MainWindow>
{
    [ObservableProperty]
    private string _toggleIconData = AppIcons.ChevronRight;
    
    [ObservableProperty]
    private HorizontalAlignment _buttonAlignment = HorizontalAlignment.Center;
    
    [ObservableProperty]
    private bool _isPaneOpen = false;
    
    [ObservableProperty]
    private ObservableCollection<NavItem> _navItems = new();
    
    [ObservableProperty]
    private NavItem? _selectedNavItem;
    
    [ObservableProperty]
    private object? _currentPage;

    private ISteamApi _steamApi;
    private IServiceProvider _serviceProvider;

    public MainViewModel(IServiceProvider serviceProvider, ISteamApi steamApi)
    {
        NavItems = new ObservableCollection<NavItem>
        {
            new NavItem 
            { 
                Title = "Home", 
                IconData = AppIcons.Home, 
                IconColor = Brushes.CornflowerBlue, 
                TargetPageType = typeof(HomeViewModel) 
            },
            new NavItem 
            { 
                Title = "Library", 
                IconData = AppIcons.Library, 
                IconColor = Brushes.PaleGreen, 
                TargetPageType = typeof(LibraryViewModel) 
            },
            new NavItem 
            { 
                Title = "Bingo", 
                IconData = AppIcons.Bingo, 
                IconColor = Brushes.LightPink, 
                TargetPageType = typeof(BingoViewModel) 
            },
            new NavItem 
            { 
                Title = "Settings", 
                IconData = AppIcons.Settings, 
                IconColor = Brushes.MediumPurple, 
                TargetPageType = typeof(SettingsViewModel) 
            }
        };

        _serviceProvider = serviceProvider;
        _steamApi = steamApi;
    }

    [RelayCommand]
    private void TogglePane() => IsPaneOpen = !IsPaneOpen;

    partial void OnSelectedNavItemChanged(NavItem? value)
    {
        if (value?.TargetPageType != null)
        {
            CurrentPage = _serviceProvider.GetRequiredService(value.TargetPageType);
        }
    }
    
    partial void OnIsPaneOpenChanged(bool value)
    {
        ButtonAlignment = ButtonAlignment == HorizontalAlignment.Center 
            ? HorizontalAlignment.Right 
            : HorizontalAlignment.Center;
        ToggleIconData = value ? AppIcons.ChevronLeft : AppIcons.ChevronRight;
    }
}