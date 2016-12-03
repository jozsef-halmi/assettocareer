using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;

namespace Assetto.Configurator.ConfigSections
{
    public class GhostCarConfig : ConfigBase
    {
        public GhostCarConfig(EventData eventData) 
        {
            this.Header = "GHOST_CAR";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("RECORDING=0");
            sb.AppendLine("PLAYING=0");
            sb.AppendLine("SECONDS_ADVANTAGE=0");
            sb.AppendLine("LOAD=1");
            sb.AppendLine("FILE=");

            return sb.ToString();
        }
    }
}
