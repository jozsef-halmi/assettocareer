using AssettoChampionship.Web.Config;
using Microsoft.Owin.Hosting;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AssettoChampionship.Web
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string baseWebAPIAddress = "http://localhost:9000/";
        public static string baseWebSignalRAddress = "http://localhost:8080/";



        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            UnityConfig.RegisterComponents();
            // Unity config
            //AreaRegistration.RegisterAllAreas();
            //UnityConfig.RegisterComponents();                           // <----- Add this line
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);


            WebApp.Start<OWINWebAPIConfig>(url: baseWebAPIAddress);
            WebApp.Start<OWINSignalRConfig>(url: baseWebSignalRAddress);
        }
    }
}
