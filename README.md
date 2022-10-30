# Avalonia.MenuFactory

[![NuGet](https://img.shields.io/nuget/v/AvaloniaMenuFactory.svg)](https://www.nuget.org/packages/AvaloniaMenuFactory) [![NuGet](https://img.shields.io/nuget/dt/AvaloniaMenuFactory.svg)](https://www.nuget.org/packages/AvaloniaMenuFactory)

**Avalonia Menu Factory** is a dynamic UI library that lets you seamlessly implement and manage a menu bar in your [Avalonia](https://avaloniaui.net/) application from only a class, where each function is a menu item.

## Usage

Avalonia Menu Factory works by reading a decorated class of methods and sending the results into an `Menu` control.

Use the static `MenuFactory.Generate()` method, passing in an instance of your [menu class](https://github.com/ArchLeaders/Avalonia.MenuFactory/blob/master/Avalonia.MenuFactory.Demo/Models/MenuModel.cs) to create the menu items. These items can then be assigned to the `Menu.Items` property.

```cs
MenuRoot = this.FindControl<Menu>("MenuRoot")!;

MenuModel menuModel = new();
MenuRoot.Items = MenuFactory.Generate(menuModel);
```

<br>

To build your menu class, decorate each method with the `Avalonia.MenuFactory.MenuAttribute` attribute where you can specify the `MenuItem` **name**, **navigation path** (e.g. `About/Help` for `About > Help > {method}`), **icon**, and **hotkey**.

```cs
[Menu("Exit", "_File", Icon = MaterialIconKind.ExitToApp, HotKey = "Alt + F4")]
public static void Exit()
{
    Environment.Exit(0);
}

[Menu("Readme", "_About/Help", Icon = MaterialIconKind.HelpOutline)]
public static void Readme()
{
    Debug.WriteLine(File.ReadAllText("../ReadMe.md"));
    // ...
}

[Menu("Credits", "_About", Icon = MaterialIconKind.PersonCheck)]
public static async void Credits()
{
    Debug.WriteLine(File.ReadAllText("../Credits.md"));
    // ...
}
```

The previous two examples will build the following menu:

<img height="195" src="https://user-images.githubusercontent.com/80713508/198862474-55c4f195-a48b-4cdd-8c2f-61739948e576.png"> <img style="border-radius: 3px;" height="195" src="https://user-images.githubusercontent.com/80713508/198863017-48240fbb-f8ee-42e8-aea5-f66d366ea428.png">

## Install

Install with NuGet or build from [source](https://github.com/ArchLeaders/Avalonia.MenuFactory).

#### NuGet
```powershell
Install-Package AvaloniaMenuFactory
```

#### Build from Source
```batch
git clone https://github.com/ArchLeaders/Avalonia.MenuFactory.git
dotnet build Avalonia.MenuFactory
```

---

**© 2022 Arch Leaders**