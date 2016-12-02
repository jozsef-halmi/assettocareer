using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Extensions;

namespace Assetto.Configurator.ConfigSections
{
    public class SessionConfig : ConfigBase
    {
        public SessionData SessionData { get; set; }

        public SessionConfig(SessionData sessionData, int sessionId = 0)
        {
            this.Header = $"[SESSION_${sessionId}]";
            this.SessionData = sessionData;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("NAME=" + this.SessionData.EventType.GetStringValue());
            sb.AppendLine("TYPE=" + this.SessionData.EventType);

            if (this.SessionData.EventType == Common.Enum.EventType.Practice 
                || this.SessionData.EventType == Common.Enum.EventType.Qualifying)
            {
                sb.AppendLine("DURATION_MINUTES="+this.SessionData.Duration);
                sb.AppendLine("SPAWN_SET=PIT");
            }
            else if (this.SessionData.EventType == Common.Enum.EventType.Race)
            {
                sb.AppendLine("LAPS="+this.SessionData.Laps);
                sb.AppendLine("SPAWN_SET=START");
                sb.AppendLine("STARTING_POSITION="+this.SessionData.StartingPosition);
                // TODO: Starting Pos
            }
            return sb.ToString();
        }

//        practice: 

//[SESSION_0]
//        NAME=Practice
//        TYPE = 1
//DURATION_MINUTES=0
//SPAWN_SET=PIT

//quickrace:

//[SESSION_0]
//        STARTING_POSITION=12
//NAME=Quick Race
//TYPE=3
//LAPS=7
//DURATION_MINUTES=0
//SPAWN_SET=START


//weekend: 
//[SESSION_0]
//        NAME=Practice
//        TYPE = 1
//DURATION_MINUTES=30
//SPAWN_SET=PIT

//[SESSION_1]
//NAME = Qualifying
//TYPE=2
//DURATION_MINUTES=25
//SPAWN_SET=PIT

//[SESSION_2]
//NAME = Race
//TYPE=3
//LAPS=7
//DURATION_MINUTES=0
//SPAWN_SET=START
    }
}
