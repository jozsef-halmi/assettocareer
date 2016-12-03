using Assetto.Common.Interfaces.Manager;
using Assetto.Manager;
using Caliburn.Micro;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssettoChampionship
{
    public class ContainerBootstrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            // Registering types
            container.RegisterType<ISeriesManager, SeriesManager>();

            // Registering instances
            if (!container.IsRegistered<ISeriesManager>())
            {
                container.RegisterInstance<ISeriesManager>(new SeriesManager());
            }


            if (!container.IsRegistered<IWindowManager>())
            {
                container.RegisterInstance<IWindowManager>(new WindowManager());
            }
            if (!container.IsRegistered<IEventAggregator>())
            {
                container.RegisterInstance<IEventAggregator>(new EventAggregator());
            }

        }
    }
}
