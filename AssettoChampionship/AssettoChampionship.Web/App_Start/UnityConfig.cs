using Assetto.Common.Interfaces.Manager;
using Assetto.Common.Interfaces.Service;
using Assetto.Manager;
using Assetto.Service;
using Assetto.Service.Utils;
using AssettoChampionship.Web.Controllers;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace AssettoChampionship.Web
{
    public static class UnityConfig
    {
        //     public static void RegisterComponents()
        //     {
        //var container = new UnityContainer();

        //         container.RegisterType<ISeriesManager, SeriesManager>();
        //         container.RegisterType<IEventManager, EventManager>();

        //         //Services
        //         container.RegisterType<ISeriesService, SeriesService>();

        //         // Utils
        //         container.RegisterType<IFileService, FileService>();
        //         container.RegisterType<IProcessService, ProcessService>();

        //         container.RegisterInstance<SeriesController>(new SeriesController(
        //             container.Resolve<ISeriesManager>()
        //             ));


        //         // register all your components with the container here
        //         // it is NOT necessary to register your controllers

        //         // e.g. container.RegisterType<ITestService, TestService>();

        //         //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        //     }

        public static IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ISeriesManager, SeriesManager>();
            container.RegisterType<IEventManager, EventManager>();

            //Services
            container.RegisterType<ISeriesService, SeriesService>();

            // Utils
            container.RegisterType<IFileService, FileService>();
            container.RegisterType<IProcessService, ProcessService>();

     

            return container;
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}