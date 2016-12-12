using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Enum;

namespace Assetto.Data
{
    public class SupportedEvents
    {
        #region Abarth500
        public static EventData Abarth500RaceEvent1 = new EventData()
        {
            Id = new Guid("a0c30bbb-936d-44c3-bcfd-6b28f18c7d65")
            , Name = "Abarth500_Magione"
            , FriendlyName = "Abarth 500 at Magione"
            , JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough
            , Track =  SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.Magione]
            , Layout = null
            , Player = SupportedPlayers.Abarth500RaceOfficial
            , Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Abarth500RaceCar]
            , EventType = EventType.QualiTwoRacesSecondReversed
            , CareerSessions = new List<SessionData>() {
                SupportedSessions.Abarth500RaceEvent1Qualy,
                SupportedSessions.Abarth500RaceEvent1Race1,
                SupportedSessions.Abarth500RaceEvent1Race2
            }
        };

        public static EventData Abarth500RaceEvent2 = new EventData()
        {
            Id = new Guid("02895201-89cf-45e7-9018-3850a2ceba30"),
            Name = "Abarth500_Brands",
            FriendlyName = "Abarth 500 at Brands Hatch",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.Brands],
            Layout = SupportedLayouts.BrandsIndy,
            Player = SupportedPlayers.Abarth500RaceOfficial,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Abarth500RaceCar],
            EventType = EventType.QualiTwoRacesSecondReversed,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.Abarth500RaceEvent2Qualy,
                SupportedSessions.Abarth500RaceEvent2Race1,
                SupportedSessions.Abarth500RaceEvent2Race2
            }
        };

        public static EventData Abarth500RaceEvent3 = new EventData()
        {
            Id = new Guid("a8c2d073-032c-477b-a304-378d33a2710b"),
            Name = "Abarth500_RedBull",
            FriendlyName = "Abarth 500 at Red Bull Ring",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.RedBullRing],
            Layout = SupportedLayouts.RedBullNational,
            Player = SupportedPlayers.Abarth500RaceOfficial,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Abarth500RaceCar],
            EventType = EventType.QualiTwoRacesSecondReversed,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.Abarth500RaceEvent3Qualy,
                SupportedSessions.Abarth500RaceEvent3Race1,
                SupportedSessions.Abarth500RaceEvent3Race2
            }
        };

        public static EventData Abarth500RaceEvent4 = new EventData()
        {
            Id = new Guid("c1cf54dd-bec3-4aa1-94c3-b837867d8eec"),
            Name = "Abarth500_Vallelunga",
            FriendlyName = "Abarth 500 at Vallelunga",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.Vallelunga],
            Layout = SupportedLayouts.VallelungaClub,
            Player = SupportedPlayers.Abarth500RaceOfficial,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Abarth500RaceCar],
            EventType = EventType.QualiTwoRacesSecondReversed,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.Abarth500RaceEvent4Qualy,
                SupportedSessions.Abarth500RaceEvent4Race1,
                SupportedSessions.Abarth500RaceEvent4Race2
            }
        };

        public static EventData Abarth500RaceEvent5TorPoznan = new EventData()
        {
            Id = new Guid("c0e6414a-48d1-4306-a3b9-496480633261"),
            Name = "Abarth500_TorPoznan",
            FriendlyName = "Abarth 500 at Tor Poznań",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.TorPoznan],
            Layout = SupportedLayouts.TorPoznanLaser,
            Player = SupportedPlayers.Abarth500RaceOfficial,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Abarth500RaceCar],
            EventType = EventType.QualiTwoRacesSecondReversed,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.Abarth500RaceEvent5Qualy,
                SupportedSessions.Abarth500RaceEvent5Race1,
                SupportedSessions.Abarth500RaceEvent5Race2
            }
        };
        #endregion Abarth500


        #region Formula3

        public static EventData Formula3PaulRicard = new EventData()
        {
            Id = new Guid("a3267660-836f-498e-b46d-16bd1d960de2"),
            Name = "Formula3_PaulRicard",
            FriendlyName = "Formula3 at Circuit Paul Ricard",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.PaulRicard],
            Layout = SupportedLayouts.PaulRicardWtcc,
            Player = SupportedPlayers.Formula3,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Formula3],
            EventType = EventType.QualiTwoRacesSecondReversed,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.Formula3PaulRicardPractice,
                SupportedSessions.Formula3PaulRicardQualy,
                SupportedSessions.Formula3PaulRicardRace1,
                SupportedSessions.Formula3PaulRicardRace2
            }
        };

        public static EventData Formula3Hring = new EventData()
        {
            Id = new Guid("b30c06f1-fcbf-448d-81ae-ff6e005d1282"),
            Name = "Formula3_Hungaroring",
            FriendlyName = "Formula3 at Hungaroring",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.Hungaroring],
            Layout = null,
            Player = SupportedPlayers.Formula3,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Formula3],
            EventType = EventType.QualiTwoRacesSecondReversed,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.Formula3HringPractice,
                SupportedSessions.Formula3HringQualy,
                SupportedSessions.Formula3HringRace1,
                SupportedSessions.Formula3HringRace2
            }
        };


        public static EventData Formula3RedBull = new EventData()
        {
            Id = new Guid("5fe29330-eafa-427b-9135-35cde55c42be"),
            Name = "Formula3_RedBull",
            FriendlyName = "Formula3 at Red Bull Ring",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.RedBullRing],
            Layout = SupportedLayouts.RedBullGp,
            Player = SupportedPlayers.Formula3,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Formula3],
            EventType = EventType.QualiTwoRacesSecondReversed,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.Formula3RedBullPractice,
                SupportedSessions.Formula3RedBullQualy,
                SupportedSessions.Formula3RedBullRace1,
                SupportedSessions.Formula3RedBullRace2
            }
        };


        public static EventData Formula3Zandvoort = new EventData()
        {
            Id = new Guid("99acc2d6-1561-4d40-a760-47a02ec12ad3"),
            Name = "Formula3_Zandvoort",
            FriendlyName = "Formula3 at Zandvoort",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.Zandvoort],
            Layout = null,
            Player = SupportedPlayers.Formula3,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Formula3],
            EventType = EventType.QualiTwoRacesSecondReversed,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.Formula3ZandvoortPractice,
                SupportedSessions.Formula3ZandvoortQualy,
                SupportedSessions.Formula3ZandvoortRace1,
                SupportedSessions.Formula3ZandvoortRace2
            }
        };


        public static EventData Formula3Spa = new EventData()
        {
            Id = new Guid("5bcdf77f-30ea-446b-906a-e24f45c75c8d"),
            Name = "Formula3_Spa",
            FriendlyName = "Formula3 at Spa Francorchamps",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.Spa],
            Layout = null,
            Player = SupportedPlayers.Formula3,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Formula3],
            EventType = EventType.QualiTwoRacesSecondReversed,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.Formula3SpaPractice,
                SupportedSessions.Formula3SpaQualy,
                SupportedSessions.Formula3SpaRace1,
                SupportedSessions.Formula3SpaRace2
            }
        };
        #endregion
    }
}
