using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;

namespace Assetto.Configurator.ConfigSections
{
    public class LightningConfig : ConfigBase
    {
        public LightningConfig(EventData eventData) : base(eventData)
        {
            this.Header = "LIGHTNING";
        }

        public override string ToString()
        {
            // TODO: ENABLE SETTING THESE VALUES
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SUN_ANGLE=16");
            sb.AppendLine("TIME_MULT=1");
            sb.AppendLine("CLOUD_SPEED=0.2");
            return sb.ToString();
        }
    }
}
