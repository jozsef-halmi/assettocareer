using Assetto.Common.DTO;
using Assetto.Common.Enum;
using Assetto.Common.Interfaces.Service;
using Assetto.Common.ProcessedResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Service
{
    public class ChampionshipService : IChampionshipService
    {
        public ISeriesService SeriesService { get; set; }
        public IResultService ResultService { get; set; }
        public ISaveService SaveService { get; set; }
        public IConfigService ConfigService { get; set; }


        public ChampionshipService(ISeriesService seriesService
            , IResultService resultService
            , ISaveService saveService
            , IConfigService configService)
        {
            this.SeriesService = seriesService;
            this.ResultService = resultService;
            this.SaveService = saveService;
            this.ConfigService = configService;
        }

        public List<ChampionshipPlayerDTO> GetCurrentStandings(string seriesId)
        {
            var series = this.SeriesService.GetSeries(seriesId);
            var standings = new List<ChampionshipPlayerDTO>();

            foreach (var seriesEvent in series.Events)
            {
                // Fill opponents
                foreach (var opponent in seriesEvent.Opponents)
                {
                    if (!standings.Any(s => s.Name == opponent.Name))
                    {
                        standings.Add(new ChampionshipPlayerDTO()
                        {
                            Name = opponent.Name,
                            Points = 0
                        });
                    }
                }

                // Fill player
                if (!standings.Any(s => s.Name == seriesEvent.Player.Name))
                {
                    standings.Add(new ChampionshipPlayerDTO()
                    {
                        Name = seriesEvent.Player.Name,
                        Points = 0
                    });
                }


                    foreach (var session in seriesEvent.CareerSessions)
                {
                    var sessionResult = SaveService.LoadResult(series.Id, seriesEvent.Id, session.Id);
                    if (sessionResult != null)
                    {
                        var sessionPoints = GetPointsForResult(sessionResult, session.SessionType, series.ChampionshipPointType);
                        foreach (var sessionPoint in sessionPoints)
                        {
                            var player = standings.FirstOrDefault(s => s.Name == sessionPoint.Name);
                            if (player == null)
                            {
                                standings.Add(sessionPoint);
                            }
                            else
                            {
                                player.Points += sessionPoint.Points;
                            }
                        }
                    }
                }
            }
            return standings;
        } 


        public List<ChampionshipPlayerDTO> GetPointsForResult(Result result, SessionType sessionType, ChampionshipPointType pointType)
        {
            switch (sessionType)
            {
                case SessionType.Qualifying:
                    // 1st gets 5 point for pole
                    return GetQualPoints(result);
                case SessionType.Race:
                    return GetRacePoints(result);
            }
            return new List<ChampionshipPlayerDTO>();
        }

        public int GetPlayerChampionshipPosition(string seriesId)
        {
            var currentStandings = GetCurrentStandings(seriesId);
            var player = currentStandings.FirstOrDefault(p => p.Name == ConfigService.GetPlayerName());
            return currentStandings.IndexOf(player)+1;
        }

        public bool IsPlayerWinning(string seriesId)
        {
            return this.GetPlayerChampionshipPosition(seriesId) == 1;
        }

        private List<ChampionshipPlayerDTO> GetQualPoints(Result result) {
            var retVar = new List<ChampionshipPlayerDTO>();
            var polePlayer = result.Players.FirstOrDefault();
            retVar.Add(new ChampionshipPlayerDTO()
            {
                Name = polePlayer.Name,
                Points = 5
            });
            return retVar;
        }

        private List<ChampionshipPlayerDTO> GetRacePoints(Result result) {
            var retVar = new List<ChampionshipPlayerDTO>();
            int[] pointsForPositions = new int[] { 25, 18, 15, 12, 10, 8, 6, 4, 2, 1 };
            for (int i = 0; i < result.Players.Count && i < 10; i++)
            {
                retVar.Add(new ChampionshipPlayerDTO() {
                    Name = result.Players.ElementAt(i).Name,
                    Points = pointsForPositions[i]
                });
            }
            return retVar;
        }
    }
}
