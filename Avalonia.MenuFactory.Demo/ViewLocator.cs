using Avalonia.Controls;
using Avalonia.Controls.Templates;
using ReactiveUI;
using System;

namespace Avalonia.MenuFactory.Demo;

public class ViewLocator : IDataTemplate
{
    public Control Build(object? data)
    {
        string? name = data?.GetType().FullName?.Replace("ViewModel", "View");
        
        if (name is not null && Type.GetType(name) is Type type) {
            return Activator.CreateInstance(type) as Control
                ?? throw new NullReferenceException();
        }
        else {
            return new TextBlock { Text = "Not Found: " + name };
        }
    }

    public bool Match(object? data)
    {
        return data is ReactiveObject;
    }
}