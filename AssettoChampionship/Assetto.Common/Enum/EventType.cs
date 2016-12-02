using Assetto.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Enum
{
    public enum EventType
    {
        [StringValue("Practice")]
        Practice = 1,

        [StringValue("Qualifying")] // Needs to be practice too
        Qualifying = 2,

        [StringValue("Quick Race")]
        Race = 3
    }
}
