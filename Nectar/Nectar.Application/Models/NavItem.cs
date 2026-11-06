using System;
using Avalonia.Controls;

namespace Nectar.Application.Models;

public class NavItem
{
    public string Title { get; set; } = string.Empty;
    public IconElement Icon { get; set; }
    public Type? TargetPageType { get; set; }
}