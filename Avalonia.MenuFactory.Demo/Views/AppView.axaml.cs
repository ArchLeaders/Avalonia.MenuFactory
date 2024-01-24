using Avalonia.Controls;
using Avalonia.MenuFactory.Demo.Models;

namespace Avalonia.MenuFactory.Demo.Views;

public partial class AppView : Window
{
    public AppView()
    {
        InitializeComponent();

        MenuModel menuModel = new();
        MenuRoot.ItemsSource = MenuFactory.Generate(menuModel);
    }
}
