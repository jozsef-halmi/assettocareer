using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Data
{
    public class DriverData
    {
        public string Name { get; set; }


        public string Nationality { get; set; }

        public SkinData Skin { get; set; }

        public CarData Car { get; set; }

        public CarConfigData CarConfig { get; set; }
    }
}
