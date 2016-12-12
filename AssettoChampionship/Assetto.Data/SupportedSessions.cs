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
        #region Abarth500Magione
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
           , Laps = 10
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
            Laps = 7,
            FriendlyName = SessionNames.REVERSED_RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top5,
               new FinishBeforeObjective() {
                   Name = "Vasco Orsino"
               }

            }
        };
        #endregion

        #region Abarth500 Brands
        public static SessionData Abarth500RaceEvent2Qualy = new SessionData()
        {
            Id = new Guid("28edf6ee-920e-43b6-a753-9c9c17a85def"),
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 10,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top5,
               new FinishBeforeObjective() {
                   Name = "Alex Pomt"
               }
            }
        };
        public static SessionData Abarth500RaceEvent2Race1 = new SessionData()
        {
            Id = new Guid("bb9a4eab-9ff4-43e3-bdb5-4c6ebc4fbcec"),
            SessionType = Common.Enum.SessionType.Race,
            Laps = 1,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Podium,
            }

        };

        public static SessionData Abarth500RaceEvent2Race2 = new SessionData()
        {
            Id = new Guid("ac4b32a5-422e-452f-8851-91243b37311a"),
            SessionType = Common.Enum.SessionType.Race,
            Laps = 1,
            FriendlyName = SessionNames.REVERSED_RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top8,
               new FinishBeforeObjective() {
                   Name = "Tristin Garrick"
               }
            }
        };

        #endregion

        #region Abarth500_RedBull
        public static SessionData Abarth500RaceEvent3Qualy = new SessionData()
        {
            Id = new Guid("63d66479-ce03-4a8d-bc9b-eaf2f5165d78"),
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 10,
            FriendlyName = SessionNames.QUALIFICATION

        };
        public static SessionData Abarth500RaceEvent3Race1 = new SessionData()
        {
            Id = new Guid("440997be-d3df-4301-8eb8-3e4cddfceba8"),
            SessionType = Common.Enum.SessionType.Race,
            Laps = 1,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top5,
               new FinishBeforeObjective() {
                   Name = "Karoly Vid"
               },
                new FinishBeforeObjective() {
                   Name = "Trenton Lorn"
               },
            }
        };

        public static SessionData Abarth500RaceEvent3Race2 = new SessionData()
        {
            Id = new Guid("50e06c1f-49f4-4704-a9eb-553f7d09e975"),
            SessionType = Common.Enum.SessionType.Race,
            Laps = 1,
            FriendlyName = SessionNames.REVERSED_RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top10,
               new FinishBeforeObjective() {
                   Name = "Erlend Braband"
               }
            }
        };
        #endregion

        #region Abarth500_Vallelunga
        public static SessionData Abarth500RaceEvent4Qualy = new SessionData()
        {
            Id = new Guid("59206910-66ce-47f5-b8de-3a78b2fb9a98"),
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 10,
            FriendlyName = SessionNames.QUALIFICATION

        };
        public static SessionData Abarth500RaceEvent4Race1 = new SessionData()
        {
            Id = new Guid("2b805cc5-3479-46ca-bca8-8ef9867bad6e"),
            SessionType = Common.Enum.SessionType.Race,
            Laps = 1,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Podium
            }

        };

        public static SessionData Abarth500RaceEvent4Race2 = new SessionData()
        {
            Id = new Guid("739f18ee-de4f-4d06-9eba-7c3e95ba4259"),
            SessionType = Common.Enum.SessionType.Race,
            Laps = 1,
            FriendlyName = SessionNames.REVERSED_RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Podium,
               new FinishBeforeObjective() {
                   Name = "Erlend Braband"
               }
            }
        };
        #endregion


        // Formula3: Paul Ricard, Hring?, Red bull Ring GP, Zandvoort, Spa, Nurburgring short, Imola

        #region Formula3_Spa
        public static SessionData Formula3SpaPractice = new SessionData()
        {
            Id = new Guid("e7dab8a8-848d-4a98-a716-623dc3166edb"),
            SessionType = Common.Enum.SessionType.Practice,
            Duration = 25,
            FriendlyName = SessionNames.PRACTICE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                new LapTimeUnderObjective() {
                    ChallengeTime = 133500 //TODO???
                }
            }
        };
        public static SessionData Formula3SpaQualy = new SessionData()
        {
            Id = new Guid("7d719c9d-dc48-4d3f-b0af-a42e2ad47c94"),
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 12,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>() {
                new LapTimeUnderObjective() {
                    ChallengeTime = 138500 //TODO???
                }
            }
        };
        public static SessionData Formula3SpaRace1 = new SessionData()
        {
            Id = new Guid("03f0c853-4ee1-47fd-9547-6da3eca96f5c"),
            SessionType = Common.Enum.SessionType.Race,
            Laps = 8,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                SupportedSessionObjectives.BestLap
            }
        };

        //

        #endregion

    }
}
