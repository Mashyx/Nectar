using Avalonia.Controls;
using Nectar.Public.ViewModels;

namespace Nectar.Public.Views;

public partial class MainWindow : Window
{
    public MainViewModel ViewModel { get; }

    public MainWindow()
    {
        InitializeComponent();
        
        ViewModel = new MainViewModel();
        DataContext = ViewModel;
    }
}