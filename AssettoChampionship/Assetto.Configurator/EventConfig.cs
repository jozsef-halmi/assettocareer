using Assetto.Common.Data;
using Assetto.Configurator.ConfigSections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.DTO;

namespace Assetto.Configurator
{
    public class EventConfig
    {
        public ConfiguredSessionDTO ConfiguredSessionDto { get; set; }

        public EventConfig(ConfiguredSessionDTO dto)
        {
            this.ConfiguredSessionDto = dto;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new RaceConfig(ConfiguredSessionDto.EventData).ToString());

            sb.AppendLine(new GhostCarConfig(ConfiguredSessionDto.EventData).ToString());

            sb.AppendLine(new ReplayConfig(ConfiguredSessionDto.EventData).ToString());

            sb.AppendLine(new LightningConfig(ConfiguredSessionDto.EventData
                , ConfiguredSessionDto.SessionData).ToString());

            sb.AppendLine(new GrooveConfig(ConfiguredSessionDto.EventData).ToString());

            sb.AppendLine(new DynamicTrackConfig(ConfiguredSessionDto.EventData
                , ConfiguredSessionDto.SessionData).ToString());

            sb.AppendLine(new LapInvalidatorConfig(ConfiguredSessionDto.EventData).ToString());

            sb.AppendLine(new TemperatureConfig(ConfiguredSessionDto.EventData
                , ConfiguredSessionDto.SessionData).ToString());

            sb.AppendLine(new WeatherConfig(ConfiguredSessionDto.EventData
                , ConfiguredSessionDto.SessionData).ToString());


            // TODO: SESSION AND OTHERS HERE
            for (int i = 0; i < ConfiguredSessionDto.EventData.GameSessions.Count; i++)
            {
                sb.AppendLine(new SessionConfig(ConfiguredSessionDto.EventData.GameSessions[i], i).ToString());
                sb.AppendLine();
            }

            sb.AppendLine(new PlayerConfig(ConfiguredSessionDto.EventData.Player).ToString());
            sb.AppendLine();

            if (ConfiguredSessionDto.SessionData.OrderedGrid != null && ConfiguredSessionDto.SessionData.OrderedGrid.Count > 0)
            {
                for (int i = 0; i < ConfiguredSessionDto.SessionData.OrderedGrid.Count; i++)
                {
                    sb.AppendLine(new OpponentConfig(ConfiguredSessionDto.SessionData.OrderedGrid[i], i + 1).ToString());
                    sb.AppendLine();
                }
            }
            else
            {
                for (int i = 0; i < ConfiguredSessionDto.EventData.Opponents.Count; i++)
                {
                    sb.AppendLine(new OpponentConfig(ConfiguredSessionDto.EventData.Opponents[i], i + 1).ToString());
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
