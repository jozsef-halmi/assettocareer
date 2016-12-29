using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Extensions;
using System.Configuration;

namespace Assetto.Configurator.ConfigSections
{
    public class SessionConfig : ConfigBase
    {
        public SessionData SessionData { get; set; }

        public SessionConfig(SessionData sessionData, int sessionId)
        {
            this.Header = $"SESSION_{sessionId}";
            this.SessionData = sessionData;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("NAME=" + this.SessionData.SessionType.GetStringValue());
            sb.AppendLine("TYPE=" + (int)this.SessionData.SessionType);

            if (this.SessionData.SessionType == Common.Enum.SessionType.Practice 
                || this.SessionData.SessionType == Common.Enum.SessionType.Qualifying)
            {
                sb.AppendLine("DURATION_MINUTES="+this.SessionData.Duration);
                sb.AppendLine("SPAWN_SET=PIT");
            }
            else if (this.SessionData.SessionType == Common.Enum.SessionType.Race)
            {
                var lapsCount = !bool.Parse(ConfigurationManager.AppSettings["DebugMode"]) ? this.SessionData.Laps : 1;
                sb.AppendLine("LAPS="+ lapsCount);
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
