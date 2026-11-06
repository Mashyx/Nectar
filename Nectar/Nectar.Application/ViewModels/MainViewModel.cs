using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Nectar.Application.Models;
using Nectar.Application.Views;

namespace Nectar.Application.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isPaneOpen = true;
    
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
            new NavItem { Title = "Home", TargetPageType = typeof(HomeView) },
            new NavItem { Title = "Library", TargetPageType = typeof(LibraryView) },
            new NavItem { Title = "Bingo", TargetPageType = typeof(BingoView) },
            new NavItem { Title = "Settings", TargetPageType = typeof(SettingsView) }
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
}
