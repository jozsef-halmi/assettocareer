using Assetto.Common.Interfaces.Manager;
using Assetto.Common.Interfaces.Service;
using Assetto.Manager;
using Assetto.Service;
using Assetto.Service.Utils;
using AssettoChampionship.ViewModels;
using Caliburn.Micro;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;

namespace AssettoChampionship
{
    public class ContainerBootstrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            // Registering types
            // Managers
            container.RegisterType<ISeriesManager, SeriesManager>();
            container.RegisterType<IEventManager, EventManager>(new ContainerControlledLifetimeManager());

            //Services
            container.RegisterType<ISeriesService, SeriesService>();
            container.RegisterType<ISaveService, SaveService>();
            container.RegisterType<IEventService, EventService>();
            container.RegisterType<IConfigService, ConfigService>(new ContainerControlledLifetimeManager());

            // Utils
            container.RegisterType<IFileService, FileService>();
            container.RegisterType<IProcessService, ProcessService>();
            container.RegisterType<IResultService, ResultService>();

            //container.RegisterType<ILogService, LogService>();


            // Registering instances
            //if (!container.IsRegistered<ISeriesManager>())
            //{
            //    container.RegisterInstance<ISeriesManager>(new SeriesManager());
            //}

            if (!container.IsRegistered<IWindowManager>())
            {
                container.RegisterInstance<IWindowManager>(new WindowManager());
            }
            if (!container.IsRegistered<IEventAggregator>())
            {
                container.RegisterInstance<IEventAggregator>(new EventAggregator());
            }

            //Viewmodels


            // View models
            //if (!container.IsRegistered<ShellViewModel>())
            //{
            //    container.RegisterInstance<ShellViewModel>(
            //        new ShellViewModel(container.Resolve<IEventAggregator>()
            //        , container));
            //}

            //if (!container.IsRegistered<MainViewModel>())
            //{
            //    container.RegisterInstance<MainViewModel>(
            //        new MainViewModel(container.Resolve<ISeriesManager>()
            //        , container.Resolve<IEventAggregator>()));
            //}

            //if (!container.IsRegistered<SeriesViewModel>())
            //{
            //    container.RegisterInstance<SeriesViewModel>(new SeriesViewModel());
            //}

        }
    }
}
