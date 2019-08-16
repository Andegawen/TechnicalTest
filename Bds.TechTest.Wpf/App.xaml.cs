using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using Bds.TechTest.Wpf.SearchService;
using Bds.TechTest.Wpf.SearchService.Bds.TechTest;

namespace Bds.TechTest.Wpf
{
    public partial class App : Application
    {
        private IContainer root;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var builder = new ContainerBuilder();
            builder.RegisterModule<SearchModule>();
            builder.RegisterType<MainViewModel>().AsSelf();
            root = builder.Build();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if(this.MainWindow != null && MainWindow.DataContext == null)
                this.MainWindow.DataContext = root.Resolve<MainViewModel>();
        }
    }
}
