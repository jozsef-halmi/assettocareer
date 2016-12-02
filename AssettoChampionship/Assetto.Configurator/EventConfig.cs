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

            sb.AppendLine(new LightningConfig(EventData).ToString());
            sb.AppendLine();

            sb.AppendLine(new DynamicTrackConfig(EventData).ToString());
            sb.AppendLine();

            sb.AppendLine(new LapInvalidatorConfig(EventData).ToString());
            sb.AppendLine();

            // TODO: SESSION AND OTHERS HERE

            sb.AppendLine(new PlayerConfig(EventData.Player).ToString());
            sb.AppendLine();

            for(int i = 0; i < EventData.Opponents.Count; i++)
            {
                sb.AppendLine(new OpponentConfig(EventData.Opponents[i], i+1).ToString());
                sb.AppendLine();
            }

            sb.AppendLine("[AUTOSPAWN]");
            sb.AppendLine("ACTIVE=1");
            sb.AppendLine();

            // TODO: AUTOSPAWN ADD

            return sb.ToString();
        }

        
    }
}
