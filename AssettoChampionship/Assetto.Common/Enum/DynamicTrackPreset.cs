using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Extensions;
using Assetto.Common.Attributes;

namespace Assetto.Common.Enum
{
    public enum DynamicTrackPreset
    {
        [StringValue("Dusty")]
        Dusty = 0,

        [StringValue("Old")]
        Old = 1,

        [StringValue("Slow")]
        Slow = 2,

        [StringValue("Green")]
        Green = 3,

        [StringValue("Fast")]
        Fast = 4,

        [StringValue("Optimum")]
        Optimum = 5,

    }
}
