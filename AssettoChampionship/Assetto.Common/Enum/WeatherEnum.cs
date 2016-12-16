using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Attributes;

namespace Assetto.Common.Enum
{
    public enum WeatherEnum
    {
        [StringValue("4_mid_clear")]
        MidClear,

        [StringValue("3_clear")]
        Clear,

        [StringValue("2_light_fog")]
        LightFog,

        [StringValue("1_heavy_fog")]
        HeavyFog,

        [StringValue("5_light_clouds")]
        LightClouds,

        [StringValue("6_mid_clouds")]
        MidClouds,

        [StringValue("7_heavy_clouds")]
        HeavyClouds,
    }
}
