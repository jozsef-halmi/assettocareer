using Assetto.Common.Data;
using Assetto.Configurator.ConfigSections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Configurator
{
    public class EventConfig
    {
        public EventData EventData { get; set; }

        public EventConfig(EventData eventData)
        {
            this.EventData = EventData;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new RaceConfig(EventData).ToString());
            sb.AppendLine();


            return sb.ToString();
        }
    }
}
