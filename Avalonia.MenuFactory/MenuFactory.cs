﻿using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.MenuFactory.Attributes;
using Material.Icons;
using Material.Icons.Avalonia;
using ReactiveUI;
using System.Reflection;

namespace Avalonia.MenuFactory
{
    public class MenuFactory
    {
        public static List<Control> Generate<T>(T obj)
        {
            if (obj == null) {
                throw new ArgumentNullException(nameof(obj), "Cannot generate menu from null reference.");
            }

            // Filter the ViewModel functions
            IEnumerable<MethodInfo> functions = obj.GetType().GetMethods().Where(x => x.GetCustomAttributes<MenuAttribute>().Any());

            // Define a new dynamic dictionary object to
            // store the sorted menu functions
            Dictionary<string, dynamic> pseudoMenu = new();

            // Iterate the sorted functions and organize
            // functions by the Path property
            foreach (var func in functions) {

                // Store the menu attribute data
                var menu = func.GetCustomAttribute<MenuAttribute>()!;

                // Null check the path
                if (menu.Path == null) {
                    pseudoMenu.Add(func.Name, func);
                    continue;
                }

                // Store the current dictionary position
                Dictionary<string, dynamic> dictPos = pseudoMenu;

                // Split the path by '.' as a separator
                // and create the required dicts for
                // each "folder" in the path
                foreach (var folder in menu.Path.Split('/')) {
                    if (!dictPos.ContainsKey(folder)) dictPos.Add(folder, new Dictionary<string, dynamic>());
                    dictPos = dictPos[folder];
                }

                // Add the last item in the tree to
                // the current dictionary
                dictPos.Add(func.Name, func);
            }

            return CollectChildItems(pseudoMenu, obj);
        }

        private static List<Control> CollectChildItems<T>(Dictionary<string, dynamic> data, T obj)
        {
            // Define the root list
            List<Control> itemsRoot = new();

            foreach ((var name, var childData) in data) {

                MenuItem child;

                if (childData is MethodInfo func) {

                    var menu = func.GetCustomAttribute<MenuAttribute>()!;
                    if (menu.IsSeparator) itemsRoot.Add(new Separator());

                    KeyGesture? shortcut = string.IsNullOrEmpty(menu.HotKey) ? null : KeyGesture.Parse(menu.HotKey);

                    child = new() {
                        Header = menu.Name ?? func.Name,
                        Icon = new MaterialIcon() { Kind = menu.Icon },
                        HotKey = shortcut,
                        InputGesture = shortcut!,
                        Height = (menu.Name ?? func.Name).StartsWith("_") ? 30 : double.NaN,
                        Command = ReactiveCommand.Create(() => {
                            func.Invoke(obj, Array.Empty<object>());
                        })
                    };

                    if (shortcut != null) {
                        HotKeyManager.SetHotKey(child, shortcut);
                    }
                }
                else if (childData is Dictionary<string, dynamic> dict) {
                    child = new() {
                        Header = name,
                        Items = CollectChildItems(dict, obj),
                    };

                    try {
                        child.Icon = new MaterialIcon() { Kind = Enum.Parse<MaterialIconKind>(name) };
                    }
                    catch { }
                }
                else {
                    throw new ArgumentException($"The passed type '{data.GetType()}' was not in the expected format.");
                }

                itemsRoot.Add(child);
            }

            return itemsRoot;
        }
    }
}
