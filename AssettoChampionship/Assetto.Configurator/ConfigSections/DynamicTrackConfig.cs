using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;

namespace Assetto.Configurator.ConfigSections
{
    public class DynamicTrackConfig : ConfigBase
    {
        public DynamicTrackConfig(EventData eventData) : base(eventData)
        {
            this.Header = "DYNAMIC_TRACK";
        }

        public override string ToString()
        {
            // TODO: ENABLE SETTING THESE VALUES
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SESSION_START=100");
            sb.AppendLine("SESSION_TRANSFER=100");
            sb.AppendLine("RANDOMNESS=0");
            sb.AppendLine("LAP_GAIN=1");
            sb.AppendLine("PRESET=5");
            return sb.ToString();
        }
    }
}
