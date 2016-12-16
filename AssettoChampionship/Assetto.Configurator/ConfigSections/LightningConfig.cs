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
        public SessionData SessionData { get; set; }
        public LightningConfig(EventData eventData, SessionData sessionData) : base(eventData)
        {
            this.Header = "LIGHTING";
            this.SessionData = sessionData;
        }

        public override string ToString()
        {
            // TODO: ENABLE SETTING THESE VALUES
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            sb.AppendLine("SUN_ANGLE="+(int)this.SessionData.TimeOfDay);
            sb.AppendLine("TIME_MULT=1");
            sb.AppendLine("CLOUD_SPEED=0.2");
            return sb.ToString();
        }
    }
}
