using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssettoChampionship.Web.Config
{
    public class OWINSignalRConfig
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseCors(CorsOptions.AllowAll);
            appBuilder.MapSignalR();
        }
    }
}
