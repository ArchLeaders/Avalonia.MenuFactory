using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.MenuFactory.Demo.ViewModels;
using Avalonia.MenuFactory.Demo.Views;
using Avalonia.Themes.Fluent;
using System;

namespace Avalonia.MenuFactory.Demo
{
    public partial class App : Application
    {
        public static AppView StaticView { get; set; } = null!;
        public static FluentTheme Theme { get; set; } = new(new Uri($"avares://{nameof(Avalonia.MenuFactory.Demo)}/Styles"));

        public override void Initialize() => AvaloniaXamlLoader.Load(this);

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                StaticView = new() {
                    DataContext = new AppViewModel()
                };

                desktop.MainWindow = StaticView;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
