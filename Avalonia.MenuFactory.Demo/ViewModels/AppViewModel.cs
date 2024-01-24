using Avalonia.Controls;
using ReactiveUI;

namespace Avalonia.MenuFactory.Demo.ViewModels;

public class AppViewModel : ReactiveObject
{
    private UserControl? content = null;
    public UserControl? Content {
        get => content;
        set => this.RaiseAndSetIfChanged(ref content, value);
    }
}
