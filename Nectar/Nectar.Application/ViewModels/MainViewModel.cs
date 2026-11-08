using System;
using System.Collections.ObjectModel;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Nectar.Application.Models;
using Nectar.Application.Views;

namespace Nectar.Application.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _toggleIconData = AppIcons.ChevronRight;
    
    [ObservableProperty]
    private bool _isPaneOpen = false;
    
    [ObservableProperty]
    private ObservableCollection<NavItem> _navItems = new();
    
    [ObservableProperty]
    private NavItem? _selectedNavItem;
    
    [ObservableProperty]
    private object? _currentPage;

    public MainViewModel()
    {
        NavItems = new ObservableCollection<NavItem>
        {
            new NavItem 
            { 
                Title = "Home", 
                IconData = AppIcons.Home, 
                IconColor = Brushes.CornflowerBlue, 
                TargetPageType = typeof(HomeView) 
            },
            new NavItem 
            { 
                Title = "Library", 
                IconData = AppIcons.Library, 
                IconColor = Brushes.PaleGreen, 
                TargetPageType = typeof(LibraryView) 
            },
            new NavItem 
            { 
                Title = "Bingo", 
                IconData = AppIcons.Bingo, 
                IconColor = Brushes.LightPink, 
                TargetPageType = typeof(BingoView) 
            },
            new NavItem 
            { 
                Title = "Settings", 
                IconData = AppIcons.Settings, 
                IconColor = Brushes.MediumPurple, 
                TargetPageType = typeof(SettingsView) 
            }
        };
    }

    [RelayCommand]
    private void TogglePane() => IsPaneOpen = !IsPaneOpen;

    partial void OnSelectedNavItemChanged(NavItem? value)
    {
        if (value?.TargetPageType != null)
        {
            CurrentPage = Activator.CreateInstance(value.TargetPageType);
        }
    }
    
    partial void OnIsPaneOpenChanged(bool value)
    {
        ToggleIconData = value ? AppIcons.ChevronLeft : AppIcons.ChevronRight;
    }
}