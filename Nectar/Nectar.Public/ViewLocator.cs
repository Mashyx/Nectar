using System;
using System.Diagnostics.CodeAnalysis;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Nectar.Public.ViewModels;
using Nectar.Public.ViewModels;

namespace Nectar.Public;

/// <summary>
/// Given a view model, returns the corresponding view if possible.
/// </summary>
[RequiresUnreferencedCode(
    "Default implementation of ViewLocator involves reflection which may be trimmed away.",
    Url = "https://docs.avaloniaui.net/docs/concepts/view-locator")]
public class ViewLocator : IDataTemplate
{
    public Control? Build(object? param)
    {
        if (param is null)
            return null;

        Type vmType = param.GetType();
        
        Type? baseType = vmType.BaseType;
        while (baseType != null)
        {
            if (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == typeof(ViewModelBase<>))
            {
                Type viewType = baseType.GetGenericArguments()[0];
                return (Control)Activator.CreateInstance(viewType)!;
            }
            baseType = baseType.BaseType;
        }

        return new TextBlock { Text = $"View not found for: {vmType.Name}" };
    }
    public bool Match(object? data)
    {
        if (data == null) return false;

        var type = data.GetType();
        while (type != null && type != typeof(object))
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ViewModelBase<>))
            {
                return true;
            }
            type = type.BaseType;
        }

        return false;
    }
}
