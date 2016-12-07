﻿using Assetto.Common.Data;
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
            this.EventData = eventData;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new RaceConfig(EventData).ToString());

            sb.AppendLine(new GhostCarConfig(EventData).ToString());

            sb.AppendLine(new ReplayConfig(EventData).ToString());

            sb.AppendLine(new LightningConfig(EventData).ToString());

            sb.AppendLine(new GrooveConfig(EventData).ToString());

            sb.AppendLine(new DynamicTrackConfig(EventData).ToString());

            sb.AppendLine(new LapInvalidatorConfig(EventData).ToString());

            sb.AppendLine(new TemperatureConfig(EventData).ToString());

            sb.AppendLine(new WeatherConfig(EventData).ToString());


            // TODO: SESSION AND OTHERS HERE
            for (int i = 0; i< EventData.GameSessions.Count; i++)
            {
                sb.AppendLine(new SessionConfig(EventData.GameSessions[i], i).ToString());
                sb.AppendLine();
            }

            sb.AppendLine(new PlayerConfig(EventData.Player).ToString());
            sb.AppendLine();


            // At the moment, only one session is supported
            var lastSessionOrderedGrid = EventData.GameSessions.Last().OrderedGrid;
            if (lastSessionOrderedGrid == null ||
                lastSessionOrderedGrid.Count == 0)
            {
                for (int i = 0; i < EventData.Opponents.Count; i++)
                {
                    sb.AppendLine(new OpponentConfig(EventData.Opponents[i], i + 1).ToString());
                    sb.AppendLine();
                }
            }
            else
            {
                for (int i = 0; i < lastSessionOrderedGrid.Count; i++)
                {
                    sb.AppendLine(new OpponentConfig(lastSessionOrderedGrid[i], i + 1).ToString());
                    sb.AppendLine();
                }
            }
          

            sb.AppendLine("[AUTOSPAWN]");
            sb.AppendLine("ACTIVE=1");
            sb.AppendLine();


            return sb.ToString();
        }

        
    }
}
