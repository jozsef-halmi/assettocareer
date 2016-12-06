using Assetto.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Comparers;
using Assetto.Common.Data;
using Assetto.Common.Enum;
using Assetto.Common.Objectives;
using Assetto.Common.Output;
using Assetto.Common.ProcessedResult;
using Assetto.Common.SaveGames;
using Assetto.Data;
using Newtonsoft.Json;

namespace Assetto.Service.Utils
{
    public class ResultService : IResultService
    {
        public Result GetResultForLog(string contents)
        {
            var outputLog =  JsonConvert.DeserializeObject<OutputLog>(contents);
            return this.ProcessResult(outputLog);
        }

        public Result ProcessResult(OutputLog outputLog)
        {
            var lastSession = outputLog.Sessions.LastOrDefault();
            if (lastSession != null)
            {
                switch (lastSession.Type)
                {
                    case SessionType.Practice:
                        return ProcessPractice(outputLog);
                    case SessionType.Qualifying:
                        return ProcessQualify(outputLog);
                    case SessionType.Race:
                        return ProcessRace(outputLog);
                }
            }
            return null;
        }

        private Result ProcessPractice(OutputLog outputLog)
        {
            // should be the same
            return this.ProcessQualify(outputLog);
        }

        private Result ProcessShared(Result result, OutputLog outputLog)
        {
            var lastSession = outputLog.Sessions.Last();

            result.Track = outputLog.Track;
            result.Duration = lastSession.Duration;
            result.LapCount = lastSession.LapsCount;
            result.SessionType = lastSession.Type;
            return result;
        }

        private Result ProcessQualify(OutputLog outputLog)
        {
            var lastSession = outputLog.Sessions.Last();

            var result = new Result();
            result = ProcessShared(result, outputLog);
            // Set the friendly name of the track
            // TODO: Check this

            //result.pr

            result.QualificationResult = GetPlayers(result, outputLog).OrderBy(p => p.BestLap, new LapTimeComparer()).ToList();
            result = FillPositions(result, outputLog);
            //result.Track = SupportedTracks.TracksDictionary[outputLog.Track].FriendlyName;
            //result.Layout = SupportedTracks.TracksDictionary[outputLog.Track].FriendlyName;

            return result;

        }

        private Result ProcessRace(OutputLog outputLog)
        {
            var lastSession = outputLog.Sessions.Last();

            var result = new Result();

            // Set the friendly name of the track
            
    
            result = ProcessShared(result, outputLog);


            result.RaceResult = GetPlayers(result, outputLog);
            result = FillPositions(result, outputLog);

            return result;
        }

        private List<ResultPlayer> GetPlayers(Result result, OutputLog outputLog)
        {
            var lastSession = outputLog.Sessions.Last();
            var results = new List<ResultPlayer>();

            // Fill the players
            for (int i = 0; i < outputLog.Players.Count(); i++)
            {
                // Get laps for the given car
                var lapsForCar = lastSession.Laps.Where(l => l.Car == i);
                var resultPlayer = new ResultPlayer()
                {
                    Name = outputLog.Players[i].Name
                    ,
                    LapCount = lapsForCar.Count()
                    ,
                    Id = i
                };

                if (lapsForCar != null)
                {

                    resultPlayer.Laps = lapsForCar.Select(l => new ResultLap()
                    {
                        Time = l.Time
                        ,
                        LapId = l.Lap
                        ,
                        Sectors = l.Sectors
                    }).ToList();
                }
                else
                {
                    // Had no time
                }
                results.Add(resultPlayer);
            }
            return results;
        }

        private Result FillPositions(Result result, OutputLog outputLog = null)
        {
            switch (result.SessionType)
            {
                case SessionType.Practice: // Should go to qualy
                case SessionType.Qualifying:
                    for (int i = 0; i < result.QualificationResult.Count; i++)
                    {
                        result.QualificationResult[i].Position = i+1;
                    }
                    break;
                case SessionType.Race:
                    var raceResults =  new List<ResultPlayer>();
                    var lastSession = outputLog.Sessions.Last();
                    for (int i = 0; i < result.RaceResult.Count; i++)
                    {
                        var carId = lastSession.RaceResult[i];
                        var playerResult = result.RaceResult.FirstOrDefault(c => c.Id == carId);
                        playerResult.Position = i+1;
                        playerResult.TotalTime = playerResult.Laps.Sum(pr => pr.Time);
                        raceResults.Add(playerResult);

                    }
                    result.RaceResult = raceResults.ToList();
                    break;
            }
            return result;
        }

        public void EvaluateSessionResult(Result result)
        {
            // Session objectives
            //result.

        }




     
    }
}
