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
        public SessionData SessionData { get; set; }
        public TemperatureConfig(EventData eventData
            , SessionData sessionData) : base(eventData)
        {
            this.Header = "TEMPERATURE";
            this.SessionData = sessionData;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("AMBIENT="+this.SessionData.AmbientTemperature);
            sb.AppendLine("ROAD="+this.SessionData.RoadTemperature);
            return sb.ToString();
        }
    }
}
