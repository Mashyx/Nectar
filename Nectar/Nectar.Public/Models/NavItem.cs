using Avalonia.Media;

namespace Nectar.Public.Models;

public class NavItem
{
    public string Title { get; set; } = string.Empty;
    public string IconData { get; set; } = string.Empty;
    public IBrush IconColor { get; set; } = Brushes.White;
    public Type? TargetPageType { get; set; }
}