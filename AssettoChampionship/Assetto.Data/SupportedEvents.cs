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
            , FriendlyName = "Abarth 500 at Magione"
            , JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough
            , Track =  SupportedTracks.TracksDictionary[Assetto.Data.Tracks.Magione]
            , Layout = null
            , Player = SupportedPlayers.Abarth500RaceOfficial
            , Opponents = SupportedOpponents.OpponentsDictionary[Cars.Abarth500RaceCar]
            , EventType = EventType.QualiTwoRacesSecondReversed
            , CareerSessions = new List<SessionData>() {
                SupportedSessions.Abarth500RaceEvent1Qualy,
                SupportedSessions.Abarth500RaceEvent1Race1,
                SupportedSessions.Abarth500RaceEvent1Race2
            }
        };
    }
}
