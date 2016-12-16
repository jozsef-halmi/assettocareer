using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Attributes;

namespace Assetto.Common.Enum
{
    public enum TimeOfDayEnum
    {
        [StringValue("8:00")]
        Time800 = -80,

        [StringValue("8:30")]
        Time830 = -72,

        [StringValue("9:00")]
        Time900 = -64,

        [StringValue("9:30")]
        Time930 = -56,

        [StringValue("10:00")]
        Time1000 = -48,

        [StringValue("10:30")]
        Time1030 = -40,

        [StringValue("11:00")]
        Time1100 = -32,

        [StringValue("11:30")]
        Time1130 = -24,

        [StringValue("12:00")]
        Time1200 = -16,

        [StringValue("12:30")]
        Time1230 = -8,

        [StringValue("13:00")]
        Time1300 = 0,

        [StringValue("13:30")]
        Time1330 = 8,

        [StringValue("14:00")]
        Time1400 = 16,

        [StringValue("14:30")]
        Time1430 = 24,

        [StringValue("15:00")]
        Time1500 = 32,

        [StringValue("15:30")]
        Time1530 = 40,

        [StringValue("16:00")]
        Time1600 = 48,

        [StringValue("16:30")]
        Time1630 = 56,

        [StringValue("17:00")]
        Time1700 = 64,

        [StringValue("17:30")]
        Time1730 = 72,

        [StringValue("18:00")]
        Time1800 = 80,
    }
}
