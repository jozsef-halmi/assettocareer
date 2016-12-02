using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;

namespace Assetto.Configurator.ConfigSections
{
    public class TemperatureConfig : ConfigBase
    {
        public TemperatureConfig(EventData eventData) : base(eventData)
        {
            this.Header = "TEMPERATURE";
        }

        public override string ToString()
        {
            // TODO: ENABLE SETTING THESE VALUES
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("AMBIENT=32");
            sb.AppendLine("ROAD=45");
            return sb.ToString();
        }
    }
}
