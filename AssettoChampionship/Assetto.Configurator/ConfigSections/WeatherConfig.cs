using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;

namespace Assetto.Configurator.ConfigSections
{
    public class WeatherConfig : ConfigBase
    {
        public WeatherConfig(EventData eventData) : base(eventData)
        {
            this.Header = "WEATHER";
        }

        public override string ToString()
        {
            // TODO: ENABLE SETTING THESE VALUES
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("NAME=3_clear");
            return sb.ToString();
        }
    }
}
