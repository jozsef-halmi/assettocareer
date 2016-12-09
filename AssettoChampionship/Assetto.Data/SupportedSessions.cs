using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Constants;
using Assetto.Common.Enum;
using Assetto.Common.Objectives;
using Assetto.Common.Extensions;

namespace Assetto.Data
{
    public class SupportedSessions
    {
        public static SessionData Abarth500RaceEvent1Qualy = new SessionData()
        {
            Id = new Guid("8b8b44ab-fc90-4b41-acd8-b905ee37d01c")
            , SessionType = Common.Enum.SessionType.Qualifying
            , Duration = 10
            , FriendlyName = SessionNames.QUALIFICATION
        };
        public static SessionData Abarth500RaceEvent1Race1 = new SessionData()
        {
            Id = new Guid("87e44ef2-59ed-47e1-8f9a-a4bfbab6bbcc")
           , SessionType = Common.Enum.SessionType.Race
           , Laps = 3
           , FriendlyName = SessionNames.RACE
           ,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Podium
            }
         
        };

        public static SessionData Abarth500RaceEvent1Race2 = new SessionData()
        {
            Id = new Guid("52519df7-3f92-4caf-9ba4-97f159826bd5"),
            SessionType = Common.Enum.SessionType.Race,
            Laps = 2,
            FriendlyName = SessionNames.REVERSED_RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Podium
            }

        };
    }
}
