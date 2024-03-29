﻿using Avalonia.MenuFactory.Attributes;
using Material.Icons;
using System;
using System.Diagnostics;
using System.IO;

namespace Avalonia.MenuFactory.Demo.Models;

public class MenuModel
{
    [Menu("Exit", "_File", Icon = MaterialIconKind.ExitToApp, HotKey = "Alt + F4")]
    public static void Exit()
    {
        Environment.Exit(0);
    }

    [Menu("Readme", "_About/Help", Icon = MaterialIconKind.HelpOutline)]
    public static void Readme()
    {
        Debug.WriteLine(File.ReadAllText("./Assets/ReadMe.md"));
        // ...
    }

    [Menu("Credits", "_About", Icon = MaterialIconKind.PersonCheck)]
    public static void Credits()
    {
        Debug.WriteLine(File.ReadAllText("./Assets/Credits.md"));
        // ...
    }
}
