using Assetto.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Helpers
{
    public static class WeatherToFriendlyString
    {
        public static string Convert(WeatherEnum weather)
        {
            switch (weather)
            {
                case WeatherEnum.MidClear:
                    return "Mid clear";
                case WeatherEnum.Clear:
                    return "Clear";
                case WeatherEnum.LightFog:
                    return "Light fog";
                case WeatherEnum.HeavyFog:
                    return "Heavy fog";
                case WeatherEnum.LightClouds:
                    return "Light clouds";
                case WeatherEnum.MidClouds:
                    return "Mid clouds";
                case WeatherEnum.HeavyClouds:
                    return "Heavy clouds";
                default:
                    return string.Empty;
            }
        }
    }
}
