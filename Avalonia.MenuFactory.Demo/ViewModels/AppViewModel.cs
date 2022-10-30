using Avalonia.Controls;
using Avalonia.MenuFactory.Demo.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.MenuFactory.Demo.ViewModels
{
    public class AppViewModel : ReactiveObject
    {
        private UserControl? content = null;
        public UserControl? Content {
            get => content;
            set => this.RaiseAndSetIfChanged(ref content, value);
        }
    }
}
