using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Unity;
using Microsoft.Practices.Unity;

namespace LearnWPFPrism
{
    public class Bootstrapper : UnityBootstrapper
    {
        public override void Run(bool runWithDefaultConfiguration)
        {
            base.Run(runWithDefaultConfiguration);
        }

        //Create the shell
        //Show the shell window

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            //Set main window for Prism
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();//User once we create a module

            Type sampleModuleType = typeof(SampleModule.SampleModule);
            ModuleCatalog.AddModule(new Prism.Modularity.ModuleInfo { ModuleName = sampleModuleType.Name, ModuleType = sampleModuleType.AssemblyQualifiedName });
        }
    }
}