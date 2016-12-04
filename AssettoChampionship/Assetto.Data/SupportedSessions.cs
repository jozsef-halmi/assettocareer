using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Data
{
    public class SupportedSessions
    {
        public static SessionData Abarth500RaceEvent1Qualy = new SessionData()
        {
            Id = Guid.NewGuid()
            , EventType = Common.Enum.EventType.Qualifying
            , Duration = 10
        };
        public static SessionData Abarth500RaceEvent1Race1 = new SessionData()
        {
            Id = Guid.NewGuid()
           , EventType = Common.Enum.EventType.Race
           , Laps = 5
        };
    }
}
