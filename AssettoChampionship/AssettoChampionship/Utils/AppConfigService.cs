using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Settings;

namespace AssettoChampionship.Utils
{
    public static class AppConfigService
    {
        public static bool IsDebugMode()
        {
            return bool.Parse(ConfigurationManager.AppSettings["DebugMode"]);
        }

        public static string VideoBaseUrl()
        {
            return ConfigurationManager.AppSettings["VideoUrl"];
        }

        
    }
}
