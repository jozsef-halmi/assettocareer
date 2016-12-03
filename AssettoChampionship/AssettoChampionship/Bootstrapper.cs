using AssettoChampionship.ViewModels;
using Caliburn.Micro;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AssettoChampionship
{
    public class Bootstrapper : BootstrapperBase
    {
        private UnityContainer Container;


        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {

            // Unity config
            this.Container =  new UnityContainer();
            ContainerBootstrapper.RegisterTypes(this.Container);

            base.Configure();
        }

        protected override object GetInstance(Type type, string name)
        {
            var result = default(object);
            if (name != null)
            {
                result = Container.Resolve(type, name);
            }
            else
            {
                result = Container.Resolve(type);
            }
            return result;
        }

        protected override IEnumerable<object> GetAllInstances(Type type)
        {
            return Container.ResolveAll(type);
        }

        protected override void BuildUp(object instance)
        {
            instance = Container.BuildUp(instance);
            base.BuildUp(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();

            // TODO: Config logging
            //// Log4net config
            //log4net.Config.XmlConfigurator.Configure();
            //var fileLogger = log4net.LogManager.GetLogger("FileAppender");
            //fileLogger.Info("Log test");



           

        }
    }
}
