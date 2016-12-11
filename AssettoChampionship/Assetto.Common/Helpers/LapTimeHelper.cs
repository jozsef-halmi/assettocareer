using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common
{
    public static class LapTimeHelper
    {
        public static string LaptimeFromInt(int lapTime)
        {
            return TimeSpan.FromMilliseconds(lapTime).ToString("mm\\:ss\\:fff");
        }
    }
}
