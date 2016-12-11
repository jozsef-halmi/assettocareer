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
            Layout = null,
            Player = SupportedPlayers.Abarth500RaceOfficial,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Abarth500RaceCar],
            EventType = EventType.QualiTwoRacesSecondReversed,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.Abarth500RaceEvent2Qualy,
                SupportedSessions.Abarth500RaceEvent2Race1,
                SupportedSessions.Abarth500RaceEvent2Race2
            }
        };
    }
}
