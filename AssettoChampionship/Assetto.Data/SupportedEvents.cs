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
        #region MazdaMX5Cup

        public static EventData MazdaMx5Cup_Magione = new EventData()
        {
            Id = "MazdaMx5Cup_Magione",
            FriendlyName = "European MX5 Cup at Magione",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.Magione],
            Layout = null,
            Player = SupportedPlayers.MazdaMx5CupPlayer,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.MazdaMx5Cup],
            EventType = EventType.QualiTwoRacesSecondReversed,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.MazdaMx5MagioneQualy,
                SupportedSessions.MazdaMx5MagioneRace1,
                SupportedSessions.MazdaMx5MagioneRace2
            },
            Description = "Driving the Mazda Mx-5 at Magione will be your first event. In these series, both young titans and less skilled drives compete. It's essential to make your debut to the series unforgettable!"
        };

        public static EventData MazdaMx5Cup_Brands = new EventData()
        {
            Id = "MazdaMx5Cup_2_Brands",
            FriendlyName = "European MX5 Cup at Brands Hatch",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.Brands],
            Layout = SupportedLayouts.BrandsIndy,
            Player = SupportedPlayers.MazdaMx5CupPlayer,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.MazdaMx5Cup],
            EventType = EventType.QualiTwoRacesSecondReversed,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.MazdaMx5BrandsQual,
                SupportedSessions.MazdaMx5BrandsRace1,
                SupportedSessions.MazdaMx5BrandsRace2
            },
            Description = "Your second race weekend is going to be on Brands Hatch, England. The expectations still aren't too high, but you have a personal rivar from the last weekend: Mark Drennan. Sponsors are interested in supporting you, so let's this weekend a be a big hit: finish before your rival and do a superb qualifying to get the sponsors!"
        };


        public static EventData MazdaMx5Cup_RedBull = new EventData()
        {
            Id = "MazdaMx5Cup_3_RedBull",
            FriendlyName = "European MX5 Cup at Red Bull Ring",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.RedBullRing],
            Layout = SupportedLayouts.RedBullNational,
            Player = SupportedPlayers.MazdaMx5CupPlayer,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.MazdaMx5Cup],
            EventType = EventType.QualiTwoRacesSecondReversed,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.MazdaMx5RedBullQual,
                SupportedSessions.MazdaMx5RedBullRace1,
                SupportedSessions.MazdaMx5RedBullRace2
            },
            Description = "The series is travelling to Austria, Red Bull Ring is going to host the third race weekend in the season. Your results are satisfying so far, let's make outstanding results: we are expecting a podium for you this weekend!"
        };


        public static EventData MazdaMx5Cup_Vallelunga = new EventData()
        {
            Id = "MazdaMx5Cup_4_Vallelunga",
            FriendlyName = "European MX5 Cup at Vallelunga",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.Vallelunga],
            Layout = SupportedLayouts.VallelungaClub,
            Player = SupportedPlayers.MazdaMx5CupPlayer,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.MazdaMx5Cup],
            EventType = EventType.QualiTwoRacesSecondReversed,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.MazdaMx5VallelungaQual,
                SupportedSessions.MazdaMx5VallelungaRace1,
                SupportedSessions.MazdaMx5VallelungaRace2
            },
            Description = "So far so good! Congratulations on your podium. The fourth race weekend is in Italy again. Vallelunga is a great opportunity for the team to score as many points as you can - we are expecting you a podium again and a strong reversed grid second race result."
        };

        public static EventData MazdaMx5Cup_Mugello = new EventData()
        {
            Id = "MazdaMx5Cup_5_TorPoznan",
            FriendlyName = "European MX5 Cup at Mugello",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.Mugello],
            Layout = null, // TODO: Check
            Player = SupportedPlayers.MazdaMx5CupPlayer,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.MazdaMx5Cup],
            EventType = EventType.QualiTwoRacesSecondReversed,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.MazdaMx5MugelloQual,
                SupportedSessions.MazdaMx5MugelloRace1,
                SupportedSessions.MazdaMx5MugelloRace2
            },

            Description = "The season finale takes place at Mugello, Italy. Winter came early, you will have to face new conditions: it's cold, and it's slippy outside, but the show must go on! Score as many points as you can to win your first series! Good luck!"
        };

        #endregion

        #region Abarth500
        public static EventData Abarth500RaceEvent1 = new EventData()
        {
            Id = "Abarth500_1_Magione"
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
            , Description = "Driving the Abarth 500 at Magione will be your first event. In these series, both young titans and less skilled drives compete. It's essential to make your debut to the series unforgettable!"
        };

        public static EventData Abarth500RaceEvent2 = new EventData()
        {
            Id = "Abarth500_2_Brands",
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
            , Description = "Your second race weekend is going to be on Brands Hatch, England. The expectations still aren't too high, but you have a personal rivar from the last weekend: Alex Pomt. Sponsors are interested in supporting you, so let's this weekend a be a big hit: finish before your rival and do a superb qualifying to get the sponsors!"
        };

        public static EventData Abarth500RaceEvent3 = new EventData()
        {
            Id = "Abarth500_3_RedBull",
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
            },
            Description = "The series is travelling to Austria, Red Bull Ring is going to host the third race weekend in the season. Your results are satisfying so far, let's make outstanding results: we are expecting a podium for you this weekend!"
        };

        public static EventData Abarth500RaceEvent4 = new EventData()
        {
            Id = "Abarth500_4_Vallelunga",
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
            },
            Description = "So far so good! Congratulations on your podium. The fourth race weekend is in Italy again. Vallelunga is a great opportunity for the team to score as many points as you can - we are expecting you a podium again and a strong reversed grid second race result."
        };

        public static EventData Abarth500RaceEvent5TorPoznan = new EventData()
        {
           Id = "Abarth500_5_TorPoznan",
            FriendlyName = "Abarth 500 at Tor Poznań",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.TorPoznan],
            Layout = SupportedLayouts.TorPoznanWinter,
            Player = SupportedPlayers.Abarth500RaceOfficial,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Abarth500RaceCar],
            EventType = EventType.QualiTwoRacesSecondReversed,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.Abarth500RaceEvent5Qualy,
                SupportedSessions.Abarth500RaceEvent5Race1,
                SupportedSessions.Abarth500RaceEvent5Race2
            },
            
            Description = "The season finale takes place at Tor Poznań, Poland. Winter came early, you will have to face new conditions: it's cold, and it's slippy outside, but the show must go on! Score as many points as you can to win your first series! Good luck!"
        };
        #endregion Abarth500


        #region Formula3

        public static EventData Formula3PaulRicard = new EventData()
        {
            Id = "Formula3_PaulRicard",
            FriendlyName = "Formula3 at Circuit Paul Ricard",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.PaulRicard],
            Layout = SupportedLayouts.PaulRicardWtcc,
            Player = SupportedPlayers.Formula3,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Formula3],
            EventType = EventType.QualiThreeRaces,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.Formula3PaulRicardPractice,
                SupportedSessions.Formula3PaulRicardQualy,
                SupportedSessions.Formula3PaulRicardRace1,
                SupportedSessions.Formula3PaulRicardRace2
            }
        };

        public static EventData Formula3Hring = new EventData()
        {
            Id = "Formula3_Hring",
            FriendlyName = "Formula3 at Hungaroring",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.Hungaroring],
            Layout = null,
            Player = SupportedPlayers.Formula3,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Formula3],
            EventType = EventType.QualiThreeRaces,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.Formula3HringPractice,
                SupportedSessions.Formula3HringQualy,
                SupportedSessions.Formula3HringRace1,
                SupportedSessions.Formula3HringRace2
            }
        };


        public static EventData Formula3RedBull = new EventData()
        {
            Id = "Formula3_RedBull",
            FriendlyName = "Formula3 at Red Bull Ring",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.RedBullRing],
            Layout = SupportedLayouts.RedBullGp,
            Player = SupportedPlayers.Formula3,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Formula3],
            EventType = EventType.QualiThreeRaces,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.Formula3RedBullPractice,
                SupportedSessions.Formula3RedBullQualy,
                SupportedSessions.Formula3RedBullRace1,
                SupportedSessions.Formula3RedBullRace2
            }
        };


        public static EventData Formula3Zandvoort = new EventData()
        {
            Id = "Formula3_Zandvoort",
            FriendlyName = "Formula3 at Zandvoort",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.Zandvoort],
            Layout = null,
            Player = SupportedPlayers.Formula3,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Formula3],
            EventType = EventType.QualiThreeRaces,
            CareerSessions = new List<SessionData>() {
                SupportedSessions.Formula3ZandvoortPractice,
                SupportedSessions.Formula3ZandvoortQualy,
                SupportedSessions.Formula3ZandvoortRace1,
                SupportedSessions.Formula3ZandvoortRace2
            }
        };


        public static EventData Formula3Spa = new EventData()
        {
            Id = "Formula3_Spa",
            FriendlyName = "Formula3 at Spa Francorchamps",
            JumpStartPenalty = Common.Enum.JumpStartPenaltyType.DriveThrough,
            Track = SupportedTracks.TracksDictionary[Assetto.Data.TrackNames.Spa],
            Layout = null,
            Player = SupportedPlayers.Formula3,
            Opponents = SupportedOpponents.OpponentsDictionary[CarNames.Formula3],
            EventType = EventType.QualiThreeRaces,
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
