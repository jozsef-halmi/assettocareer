using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Data
{
    public static class SupportedClasses
    {

        public static ClassData Mx5 = new ClassData()
        {
            Name = "Mx5",
            FriendlyName = "MX-5 Cup"
        };

        public static ClassData GT4 = new ClassData()
        {
            Name = "GT4",
            FriendlyName = "GT4"
        };

        public static ClassData Abarth = new ClassData()
        {
            Name = "Abarth500",
            FriendlyName = "Abarth 500"
        };
    }
}
