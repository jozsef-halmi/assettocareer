using Assetto.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Enum
{
    public enum SessionType
    {
        [StringValue("Practice")]
        Practice = 1,

        [StringValue("Qualification")] // Needs to be practice too
        Qualifying = 2,

        [StringValue("Race")]
        Race = 3
    }
}
