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

        public ChampionshipService(ISeriesService seriesService
            , IResultService resultService
            , ISaveService saveService)
        {
            this.SeriesService = seriesService;
            this.ResultService = resultService;
            this.SaveService = saveService;
        }

        public List<ChampionshipPlayerDTO> GetCurrentStandings(Guid seriesId)
        {
            var series = this.SeriesService.GetSeries(seriesId);

            var standings = new List<ChampionshipPlayerDTO>();

            foreach (var seriesEvent in series.Events)
            {
                foreach (var session in seriesEvent.CareerSessions)
                {
                    var sessionResult = SaveService.LoadResult(series.Id, seriesEvent.Id, session.Id);
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
