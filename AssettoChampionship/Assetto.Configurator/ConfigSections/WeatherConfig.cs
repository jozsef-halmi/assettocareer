using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Extensions;

namespace Assetto.Configurator.ConfigSections
{
    public class WeatherConfig : ConfigBase
    {
        public SessionData SessionData { get; set; }
        public WeatherConfig(EventData eventData, SessionData sessionData) : base(eventData)
        {
            this.Header = "WEATHER";
            this.SessionData = sessionData;
        }

        public override string ToString()
        {
            // TODO: ENABLE SETTING THESE VALUES
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("NAME="+this.SessionData.Weather.GetStringValue());
            return sb.ToString();
        }
    }
}
