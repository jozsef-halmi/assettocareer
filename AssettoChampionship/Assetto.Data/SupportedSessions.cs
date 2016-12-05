using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Objectives;

namespace Assetto.Data
{
    public class SupportedSessions
    {
        public static SessionData Abarth500RaceEvent1Qualy = new SessionData()
        {
            Id = new Guid("8b8b44ab-fc90-4b41-acd8-b905ee37d01c")
            , EventType = Common.Enum.EventType.Qualifying
            , Duration = 10
        };
        public static SessionData Abarth500RaceEvent1Race1 = new SessionData()
        {
            Id = new Guid("87e44ef2-59ed-47e1-8f9a-a4bfbab6bbcc")
           , EventType = Common.Enum.EventType.Race
           , Laps = 5
            , PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Win
            }
         
        };
    }
}
