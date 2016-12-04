using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Data
{
    public class SupportedEvents
    {
        public static EventData Abarth500RaceEvent1 = new EventData()
        {
            Id = Guid.NewGuid()
            , FriendlyName = "Abarth 500 at Magione"
            , JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough
            , Track =  SupportedTracks.TracksDictionary[Assetto.Data.Tracks.Magione]
            , Layout = null
            , Player = SupportedPlayers.Abarth500RaceOfficial
            , Opponents = SupportedOpponents.OpponentsDictionary[Cars.Abarth500RaceCar]
            , CareerSessions = new List<SessionData>() {
                SupportedSessions.Abarth500RaceEvent1Qualy
                , SupportedSessions.Abarth500RaceEvent1Race1
            }
        };
    }
}
