﻿using Assetto.Common.Data;
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
        #region Mx5_Magione

        public static SessionData MazdaMx5MagioneQualy = new SessionData()
        {
            Id = "MX5_Magione_Q",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 10,
            TimeOfDay = TimeOfDayEnum.Time900,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.Clear,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Under107Percentage
            }
        };

        public static SessionData MazdaMx5MagioneRace1 = new SessionData()
        {
            Id = "MX5_Magione_R1",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 7,
            TimeOfDay = TimeOfDayEnum.Time1300,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.Clear,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top5
            }
        };

        public static SessionData MazdaMx5MagioneRace2 = new SessionData()
        {
            Id = "MX5_Magione_R2",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 6,
            TimeOfDay = TimeOfDayEnum.Time1700,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.Clear,
            FriendlyName = SessionNames.REVERSED_RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top8,
            }
        };

        #endregion

        #region Mx5_Brands
        public static SessionData MazdaMx5BrandsQual = new SessionData()
        {
            Id = "MX5_Brands_Q",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 10,
            TimeOfDay = TimeOfDayEnum.Time800,
            AmbientTemperature = 25,
            DynamicTrack = DynamicTracks.Old,
            Weather = WeatherEnum.LightClouds,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top10,
               new FinishBeforeObjective() {
                   Name = "Mark Drennan"
               },
                SupportedSessionObjectives.Under107Percentage,
                new LapTimeUnderObjective()
                {
                    ChallengeTime = 59000
                }

            }
        };
        public static SessionData MazdaMx5BrandsRace1 = new SessionData()
        {
            Id = "MX5_Brands_R1",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 9,
            TimeOfDay = TimeOfDayEnum.Time1300,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Slow,
            Weather = WeatherEnum.LightClouds,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top8,
                  new FinishBeforeObjective() {
                   Name = "Mark Drennan"
               },
            }

        };

        public static SessionData MazdaMx5BrandsRace2 = new SessionData()
        {
            Id = "MX5_Brands_R2",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 8,
            FriendlyName = SessionNames.REVERSED_RACE,
            TimeOfDay = TimeOfDayEnum.Time1800,
            AmbientTemperature = 24,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightClouds,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top8,
            }
        };

        #endregion

        #region Mx5_RedBull
        public static SessionData MazdaMx5RedBullQual = new SessionData()
        {
            Id = "MX5_RedBull_Q",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 10,
            TimeOfDay = TimeOfDayEnum.Time900,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightClouds,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Under107Percentage,
                 new FinishBeforeObjective() {
                   Name = "Mark Drennan"
               }
            }

        };
        public static SessionData MazdaMx5RedBullRace1 = new SessionData()
        {
            Id = "MX5_RedBull_R1",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 8,
            TimeOfDay = TimeOfDayEnum.Time1300,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightClouds,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Podium,

            }
        };

        public static SessionData MazdaMx5RedBullRace2 = new SessionData()
        {
            Id = "MX5_RedBull_R2",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 7,
            TimeOfDay = TimeOfDayEnum.Time1630,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightClouds,
            FriendlyName = SessionNames.REVERSED_RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top10,
               new FinishBeforeObjective() {
                   Name = "Nikko Reger"
               }
            }
        };
        #endregion

        #region Mx5_Vallelunga
        public static SessionData MazdaMx5VallelungaQual = new SessionData()
        {
            Id = "MX5_Vallelunga_Q",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 10,
            TimeOfDay = TimeOfDayEnum.Time900,
            AmbientTemperature = 25,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightClouds,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Under107Percentage
            }

        };
        public static SessionData MazdaMx5VallelungaRace1 = new SessionData()
        {
            Id = "MX5_Vallelunga_R1",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 8,
            TimeOfDay = TimeOfDayEnum.Time1300,
            AmbientTemperature = 25,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightClouds,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Podium,
               SupportedSessionObjectives.BestLap
            }

        };

        public static SessionData MazdaMx5VallelungaRace2 = new SessionData()
        {
            Id = "MX5_Vallelunga_R2",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 7,
            TimeOfDay = TimeOfDayEnum.Time1700,
            AmbientTemperature = 25,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightClouds,
            FriendlyName = SessionNames.REVERSED_RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top5,
            }
        };
        #endregion

        #region Mx5_Mugello
        public static SessionData MazdaMx5MugelloQual = new SessionData()
        {
            Id = "MX5_Mugello_Q",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 10,
            FriendlyName = SessionNames.QUALIFICATION,
            TimeOfDay = TimeOfDayEnum.Time900,
            AmbientTemperature = 10,
            DynamicTrack = DynamicTracks.Dusty,
            Weather = WeatherEnum.HeavyFog,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Under107Percentage
            }

        };
        public static SessionData MazdaMx5MugelloRace1 = new SessionData()
        {
            Id = "MX5_Mugello_R1",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 8,
            FriendlyName = SessionNames.RACE,
            TimeOfDay = TimeOfDayEnum.Time1430,
            AmbientTemperature = 12,
            DynamicTrack = DynamicTracks.Dusty,
            Weather = WeatherEnum.HeavyFog,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Podium
            }

        };

        public static SessionData MazdaMx5MugelloRace2 = new SessionData()
        {
            Id = "MX5_Mugello_R2",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 7,
            TimeOfDay = TimeOfDayEnum.Time1700,
            AmbientTemperature = 10,
            DynamicTrack = DynamicTracks.Dusty,
            Weather = WeatherEnum.LightFog,
            FriendlyName = SessionNames.REVERSED_RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Podium,
               new FinishBeforeObjective() {
                   Name = "Chris Stone"
               }
            }
        };
        #endregion

        #region PorscheGT4_Monza

        public static SessionData PorscheGT4MonzaPract = new SessionData()
        {
            Id = "PorscheGT4_Monza_P",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 60,
            TimeOfDay = TimeOfDayEnum.Time800,
            AmbientTemperature = 20,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightFog,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Do5Laps
            }
        };


        public static SessionData PorscheGT4MonzaQualy = new SessionData()
        {
            Id = "PorscheGT4_Monza_Q",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 30,
            TimeOfDay = TimeOfDayEnum.Time1200,
            AmbientTemperature = 26,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.MidClear,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Under107Percentage
            }
        };

        public static SessionData PorscheGT4MonzaRace1 = new SessionData()
        {
            Id = "PorscheGT4_Monza_R1",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 12,
            TimeOfDay = TimeOfDayEnum.Time1600,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Fast,
            Weather = WeatherEnum.Clear,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top5
            }
        };


        #endregion

        #region PorscheGT4_Silverstone

        public static SessionData PorscheGT4SilverstonePract = new SessionData()
        {
            Id = "PorscheGT4_Silverstone_P",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 60,
            TimeOfDay = TimeOfDayEnum.Time800,
            AmbientTemperature = 20,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightFog,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Do5Laps
            }
        };


        public static SessionData PorscheGT4SilverstoneQualy = new SessionData()
        {
            Id = "PorscheGT4_Silverstone_Q",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 30,
            TimeOfDay = TimeOfDayEnum.Time1200,
            AmbientTemperature = 26,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.MidClear,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Under107Percentage,
                new LapTimeUnderObjective()
                {
                    ChallengeTime = 137000
                }
            }
        };

        public static SessionData PorscheGT4SilverstoneRace1 = new SessionData()
        {
            Id = "PorscheGT4_Silverstone_R1",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 11,
            TimeOfDay = TimeOfDayEnum.Time1600,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Fast,
            Weather = WeatherEnum.Clear,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top5
            }
        };


        #endregion

        #region PorscheGT4_Barcelona

        public static SessionData PorscheGT4BarcelonaPract = new SessionData()
        {
            Id = "PorscheGT4_Barcelona_P",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 60,
            TimeOfDay = TimeOfDayEnum.Time800,
            AmbientTemperature = 20,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightFog,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Do5Laps
            }
        };


        public static SessionData PorscheGT4BarcelonaQualy = new SessionData()
        {
            Id = "PorscheGT4_Barcelona_Q",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 30,
            TimeOfDay = TimeOfDayEnum.Time1200,
            AmbientTemperature = 26,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.MidClear,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Under107Percentage
            }
        };

        public static SessionData PorscheGT4BarcelonaRace1 = new SessionData()
        {
            Id = "PorscheGT4_Barcelona_R1",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 11,
            TimeOfDay = TimeOfDayEnum.Time1600,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Fast,
            Weather = WeatherEnum.Clear,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top5
            }
        };


        #endregion


        #region PorscheGT4_Spa

        public static SessionData PorscheGT4SpaPract = new SessionData()
        {
            Id = "PorscheGT4_Spa_P",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 60,
            TimeOfDay = TimeOfDayEnum.Time800,
            AmbientTemperature = 20,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightFog,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Do5Laps
            }
        };


        public static SessionData PorscheGT4SpaQualy = new SessionData()
        {
            Id = "PorscheGT4_Spa_Q",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 30,
            TimeOfDay = TimeOfDayEnum.Time1200,
            AmbientTemperature = 26,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.MidClear,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Under107Percentage
            }
        };

        public static SessionData PorscheGT4SpaRace1 = new SessionData()
        {
            Id = "PorscheGT4_Spa_R1",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 11,
            TimeOfDay = TimeOfDayEnum.Time1600,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Fast,
            Weather = WeatherEnum.Clear,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top5
            }
        };


        #endregion


        #region PorscheGT4_Zandvoort

        public static SessionData PorscheGT4ZandvoortPract = new SessionData()
        {
            Id = "PorscheGT4_Zandvoort_P",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 60,
            TimeOfDay = TimeOfDayEnum.Time800,
            AmbientTemperature = 20,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightFog,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Do5Laps
            }
        };


        public static SessionData PorscheGT4ZandvoortQualy = new SessionData()
        {
            Id = "PorscheGT4_Zandvoort_Q",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 30,
            TimeOfDay = TimeOfDayEnum.Time1200,
            AmbientTemperature = 26,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.MidClear,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Under107Percentage
            }
        };

        public static SessionData PorscheGT4ZandvoortRace1 = new SessionData()
        {
            Id = "PorscheGT4_Zandvoort_R1",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 11,
            TimeOfDay = TimeOfDayEnum.Time1600,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Fast,
            Weather = WeatherEnum.Clear,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top5
            }
        };


        #endregion


        #region Abarth500Magione

        public static SessionData Abarth500RaceEvent1Qualy = new SessionData()
        {
            Id = "8b8b44ab-fc90-4b41-acd8-b905ee37d01c"
         ,
            SessionType = Common.Enum.SessionType.Qualifying
         ,
            Duration = 10
         ,
            TimeOfDay = TimeOfDayEnum.Time900
         ,
            AmbientTemperature = 32
         ,
            DynamicTrack = DynamicTracks.Green
         ,
            Weather = WeatherEnum.Clear
         ,
            FriendlyName = SessionNames.QUALIFICATION
         ,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Under107Percentage
            }
        };
        public static SessionData Abarth500RaceEvent1Race1 = new SessionData()
        {
            Id = "87e44ef2-59ed-47e1-8f9a-a4bfbab6bbcc"
           , SessionType = Common.Enum.SessionType.Race
           , Laps = 7,
              TimeOfDay = TimeOfDayEnum.Time1300,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.Clear
           , FriendlyName = SessionNames.RACE
           ,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top10
            }
        };

        public static SessionData Abarth500RaceEvent1Race2 = new SessionData()
        {
            Id = "52519df7-3f92-4caf-9ba4-97f159826bd5",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 6,
            TimeOfDay = TimeOfDayEnum.Time1700,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.Clear,
            FriendlyName = SessionNames.REVERSED_RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top8,
               //new FinishBeforeObjective() {
               //    Name = "Vasco Orsino"
               //}
            }
        };
        #endregion

        #region Abarth500 Brands
        public static SessionData Abarth500RaceEvent2Qualy = new SessionData()
        {
            Id = "28edf6ee-920e-43b6-a753-9c9c17a85def",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 10,
            TimeOfDay = TimeOfDayEnum.Time800,
            AmbientTemperature = 25,
            DynamicTrack = DynamicTracks.Old,
            Weather = WeatherEnum.LightClouds,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top10,
               new FinishBeforeObjective() {
                   Name = "Alex Pomt"
               },
                SupportedSessionObjectives.Under107Percentage,
                new LapTimeUnderObjective()
                {
                    ChallengeTime = 60500
                }

            }
        };
        public static SessionData Abarth500RaceEvent2Race1 = new SessionData()
        {
            Id = "bb9a4eab-9ff4-43e3-bdb5-4c6ebc4fbcec",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 9,
            TimeOfDay = TimeOfDayEnum.Time1300,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Slow,
            Weather = WeatherEnum.LightClouds,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top8,
                  new FinishBeforeObjective() {
                   Name = "Alex Pomt"
               },
            }

        };

        public static SessionData Abarth500RaceEvent2Race2 = new SessionData()
        {
            Id = "ac4b32a5-422e-452f-8851-91243b37311a",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 8,
            FriendlyName = SessionNames.REVERSED_RACE,
            TimeOfDay = TimeOfDayEnum.Time1800,
            AmbientTemperature = 24,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightClouds,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top8,
              
               //new FinishBeforeObjective() {
               //    Name = "Tristin Garrick"
               //}
            }
        };

        #endregion

        #region Abarth500_RedBull
        public static SessionData Abarth500RaceEvent3Qualy = new SessionData()
        {
            Id = "63d66479-ce03-4a8d-bc9b-eaf2f5165d78",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 10,
            TimeOfDay = TimeOfDayEnum.Time900,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightClouds,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Under107Percentage,
                 new FinishBeforeObjective() {
                   Name = "Alex Pomt"
               }
            }

        };
        public static SessionData Abarth500RaceEvent3Race1 = new SessionData()
        {
            Id = "440997be-d3df-4301-8eb8-3e4cddfceba8",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 8,
            TimeOfDay = TimeOfDayEnum.Time1300,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightClouds,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Podium,
            
            }
        };

        public static SessionData Abarth500RaceEvent3Race2 = new SessionData()
        {
            Id = "50e06c1f-49f4-4704-a9eb-553f7d09e975",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 7,
            TimeOfDay = TimeOfDayEnum.Time1630,
            AmbientTemperature = 32,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightClouds,
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
            Id = "59206910-66ce-47f5-b8de-3a78b2fb9a98",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 10,
            TimeOfDay = TimeOfDayEnum.Time900,
            AmbientTemperature = 25,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightClouds,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Under107Percentage
            }

        };
        public static SessionData Abarth500RaceEvent4Race1 = new SessionData()
        {
            Id = "2b805cc5-3479-46ca-bca8-8ef9867bad6e",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 8,
            TimeOfDay = TimeOfDayEnum.Time1300,
            AmbientTemperature = 25,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightClouds,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Podium,
               SupportedSessionObjectives.BestLap
            }

        };

        public static SessionData Abarth500RaceEvent4Race2 = new SessionData()
        {
            Id = "739f18ee-de4f-4d06-9eba-7c3e95ba4259",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 7,
            TimeOfDay = TimeOfDayEnum.Time1700,
            AmbientTemperature = 25,
            DynamicTrack = DynamicTracks.Green,
            Weather = WeatherEnum.LightClouds,
            FriendlyName = SessionNames.REVERSED_RACE,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Top5,
            }
        };
        #endregion


        #region Abarth500_TorPoznan
        public static SessionData Abarth500RaceEvent5Qualy = new SessionData()
        {
            Id = "82add6cd-0389-4cb9-b6eb-6813ee518a7d",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 10,
            FriendlyName = SessionNames.QUALIFICATION,
            TimeOfDay = TimeOfDayEnum.Time900,
            AmbientTemperature = 10,
            DynamicTrack =  DynamicTracks.Dusty,
            Weather = WeatherEnum.HeavyFog,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
                SupportedSessionObjectives.Under107Percentage
            }

        };
        public static SessionData Abarth500RaceEvent5Race1 = new SessionData()
        {
            Id = "f3fdf448-48ba-4f66-ae63-7bc2bba77f3d",
            SessionType = Common.Enum.SessionType.Race,
            Laps =8,
            FriendlyName = SessionNames.RACE,
            TimeOfDay = TimeOfDayEnum.Time1430,
            AmbientTemperature = 12,
            DynamicTrack = DynamicTracks.Dusty,
            Weather = WeatherEnum.HeavyFog,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Podium
            }

        };

        public static SessionData Abarth500RaceEvent5Race2 = new SessionData()
        {
            Id = "93b73df3-b4cc-4d55-badd-ffb3b6778640",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 7,
            TimeOfDay = TimeOfDayEnum.Time1700,
            AmbientTemperature = 10,
            DynamicTrack = DynamicTracks.Dusty,
            Weather = WeatherEnum.LightFog,
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

        #region Formula3_PaulRicard
        public static SessionData Formula3PaulRicardPractice = new SessionData()
        {
            Id = "a3ac3788-60ad-4a9d-be20-5d25a827d7ad",
            SessionType = Common.Enum.SessionType.Practice,
            Duration = 25,
            FriendlyName = SessionNames.PRACTICE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                new LapTimeUnderObjective() {
                    ChallengeTime = 133500 //TODO???
                }
            }
        };
        public static SessionData Formula3PaulRicardQualy = new SessionData()
        {
            Id = "11ad4d4f-ee0c-4ab5-b1f0-8d9d996f44e5",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 12,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Under107Percentage
            }
        };
        public static SessionData Formula3PaulRicardRace1 = new SessionData()
        {
            Id = "2c753529-7fd0-48bd-846e-c5913ba58d75",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 8,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                SupportedSessionObjectives.BestLap
            }
        };

        public static SessionData Formula3PaulRicardRace2 = new SessionData()
        {
            Id = "cebf9b43-1610-4b41-b121-29dda353e14b",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 7,
            FriendlyName = SessionNames.REVERSED_RACE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                SupportedSessionObjectives.Top5
            }
        };


        #endregion


        #region Formula3_Hungaroring
        public static SessionData Formula3HringPractice = new SessionData()
        {
            Id = "0dbc1e38-cf0e-47a2-a447-0f3beb719e05",
            SessionType = Common.Enum.SessionType.Practice,
            Duration = 25,
            FriendlyName = SessionNames.PRACTICE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                new LapTimeUnderObjective() {
                    ChallengeTime = 133500 //TODO???
                }
            }
        };
        public static SessionData Formula3HringQualy = new SessionData()
        {
            Id = "e7c379bf-f33c-4847-bc21-d6d7a197be64",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 12,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>() {
                new LapTimeUnderObjective() {
                    ChallengeTime = 138500 //TODO???
                }
            }
        };
        public static SessionData Formula3HringRace1 = new SessionData()
        {
            Id = "6cfa4c81-39af-4a2f-a7e2-8bd49277c06d",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 8,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                SupportedSessionObjectives.BestLap
            }
        };

        public static SessionData Formula3HringRace2 = new SessionData()
        {
            Id = "0ef4c1f5-8ba6-49a1-a50f-ff351dccf99c",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 7,
            FriendlyName = SessionNames.REVERSED_RACE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                SupportedSessionObjectives.Top5
            }
        };


        #endregion

        #region Formula3_RedBullRing
        public static SessionData Formula3RedBullPractice = new SessionData()
        {
            Id = "a0f7358b-6f12-45a2-b9b8-cf6177bd0ef6",
            SessionType = Common.Enum.SessionType.Practice,
            Duration = 25,
            FriendlyName = SessionNames.PRACTICE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                new LapTimeUnderObjective() {
                    ChallengeTime = 90000
                }
            }
        };
        public static SessionData Formula3RedBullQualy = new SessionData()
        {
            Id = "a73363ab-5cfd-47dd-ba21-ac3ebd10a4b7",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 12,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Under107Percentage
            }
        };
        public static SessionData Formula3RedBullRace1 = new SessionData()
        {
            Id = "b337c09e-e5bf-43e3-a994-7d193675e784",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 8,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                SupportedSessionObjectives.BestLap
            }
        };

        public static SessionData Formula3RedBullRace2 = new SessionData()
        {
            Id = "2b2754d5-c067-4ac2-9262-1a990e07316b",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 7,
            FriendlyName = SessionNames.REVERSED_RACE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                SupportedSessionObjectives.Top5
            }
        };

        #endregion

        #region Formula3_Zandvoort
        public static SessionData Formula3ZandvoortPractice = new SessionData()
        {
            Id = "6cb1e1d8-be91-4dc4-94ac-953e05b7128f",
            SessionType = Common.Enum.SessionType.Practice,
            Duration = 25,
            FriendlyName = SessionNames.PRACTICE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                new LapTimeUnderObjective() {
                    ChallengeTime = 96500
                }
            }
        };
        public static SessionData Formula3ZandvoortQualy = new SessionData()
        {
            Id = "f9d60c27-c758-438e-89fe-a5a5a7af07d3",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 12,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>()
            {
               SupportedSessionObjectives.Under107Percentage
            }
        };
        public static SessionData Formula3ZandvoortRace1 = new SessionData()
        {
            Id = "ecf9997a-5f68-4fd7-aa17-0c9236b9e0ad",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 8,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                SupportedSessionObjectives.BestLap
            }
        };

        public static SessionData Formula3ZandvoortRace2 = new SessionData()
        {
            Id = "a1217643-35db-4ef7-8f64-292aa29f5272",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 7,
            FriendlyName = SessionNames.REVERSED_RACE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                SupportedSessionObjectives.Top5
            }
        };

        #endregion

        #region Formula3_Spa
        public static SessionData Formula3SpaPractice = new SessionData()
        {
            Id = "e7dab8a8-848d-4a98-a716-623dc3166edb",
            SessionType = Common.Enum.SessionType.Practice,
            Duration = 25,
            FriendlyName = SessionNames.PRACTICE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                new LapTimeUnderObjective() {
                    ChallengeTime = 139000 
                }
            }
        };
        public static SessionData Formula3SpaQualy = new SessionData()
        {
            Id = "7d719c9d-dc48-4d3f-b0af-a42e2ad47c94",
            SessionType = Common.Enum.SessionType.Qualifying,
            Duration = 12,
            FriendlyName = SessionNames.QUALIFICATION,
            PrimarySessionObjectives = new List<SessionObjective>() {
                new LapTimeUnderObjective() {
                    ChallengeTime = 137900 
                }
            }
        };
        public static SessionData Formula3SpaRace1 = new SessionData()
        {
            Id = "03f0c853-4ee1-47fd-9547-6da3eca96f5c",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 8,
            FriendlyName = SessionNames.RACE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                SupportedSessionObjectives.BestLap
            }
        };

        public static SessionData Formula3SpaRace2 = new SessionData()
        {
            Id = "0df16f21-0ef2-4b03-8f43-b4aef81b1d27",
            SessionType = Common.Enum.SessionType.Race,
            Laps = 7,
            FriendlyName = SessionNames.REVERSED_RACE,
            PrimarySessionObjectives = new List<SessionObjective>() {
                SupportedSessionObjectives.Top5
            }
        };

        //

        #endregion

    }
}
