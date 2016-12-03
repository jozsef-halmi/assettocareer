using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;

namespace Assetto.Configurator.ConfigSections
{
    public class GrooveConfig : ConfigBase
    {
        public GrooveConfig(EventData eventData) 
        {
            this.Header = "GROOVE";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("VIRTUAL_LAPS=10");
            sb.AppendLine("MAX_LAPS=30");
            sb.AppendLine("STARTING_LAPS=0");

            return sb.ToString();
        }
    }
}
