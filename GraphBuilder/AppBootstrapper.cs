using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using GraphBuilder.ViewModels;

namespace GraphBuilder
{
    class AppBootstrapper : BootstrapperBase
    {
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            var settings = new Dictionary<string, object>{
                { "ResizeMode", ResizeMode.NoResize },
                { "Title", "Graph Builder" },
                { "Height", 728 },
                { "Width", 1024 },
                { "WindowStartupLocation", WindowStartupLocation.CenterScreen }
            };

            DisplayRootViewFor<MainViewModel>(settings);

            base.OnStartup(sender, e);
        }
    }
}
