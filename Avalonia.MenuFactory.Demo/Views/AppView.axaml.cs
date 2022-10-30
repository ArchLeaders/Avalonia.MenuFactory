using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.MenuFactory.Demo.Models;

namespace Avalonia.MenuFactory.Demo.Views
{
    public partial class AppView : Window
    {
        public AppView()
        {
            AvaloniaXamlLoader.Load(this);
            this.AttachDevTools();

            MenuRoot = this.FindControl<Menu>("MenuRoot")!;

            MenuModel menuModel = new();
            MenuRoot.Items = MenuFactory.Generate(menuModel);
        }
    }
}
