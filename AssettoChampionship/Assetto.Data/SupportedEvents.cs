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
        #endregion Abarth500


        #region Formula3

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
                SupportedSessions.Formula3SpaRace1
            }
        };
        #endregion
    }
}
