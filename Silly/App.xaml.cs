using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Silly.UI.Shell.ViewModels;

namespace Silly
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SillyBootstrapper bootstrapper = new SillyBootstrapper();
            bootstrapper.Initialize();
            var windowManager = IoC.Get<IWindowManager>();
            windowManager.ShowDialog(new ShellViewModel());
        }
    }
}
