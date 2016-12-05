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
using Assetto.Data;
using Newtonsoft.Json;

namespace Assetto.Service.Utils
{
    public class ResultService : IResultService
    {
        public Result GetResult(string contents)
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
                    case EventType.Practice:
                        return ProcessPractice(outputLog);
                    case EventType.Qualifying:
                        return ProcessQualify(outputLog);
                    case EventType.Race:
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

        private Result ProcessQualify(OutputLog outputLog)
        {
            var lastSession = outputLog.Sessions.Last();

            var result = new Result();

            // Set the friendly name of the track
            // TODO: Check this
            result.Track = outputLog.Track;
            result.Duration = lastSession.Duration;
            result.LapCount = lastSession.LapsCount;
            result.EventType = lastSession.Type;

            var qualyResults = new List<ResultPlayer>();

            // Fill the players
            for (int i = 0; i < outputLog.Players.Count(); i++)
            {
                // Get laps for the given car
                var lapsForCar = lastSession.Laps.Where(l => l.Car == i);
                var resultPlayer = new ResultPlayer()
                {
                    Name = outputLog.Players[i].Name
                    , LapCount = lapsForCar.Count()
                    , Id = i
                };

                if (lapsForCar != null)
                {

                    resultPlayer.Laps = lapsForCar.Select(l => new ResultLap()
                    {
                        Time = l.Time
                        , LapId = l.Lap
                        , Sectors = l.Sectors
                    }).ToList();
                }
                else
                {
                    // Had no time
                }
                qualyResults.Add(resultPlayer);
            }

            result.QualificationResult = qualyResults.OrderBy(p => p.BestLap, new LapTimeComparer()).ToList();

            //result.Track = SupportedTracks.TracksDictionary[outputLog.Track].FriendlyName;
            //result.Layout = SupportedTracks.TracksDictionary[outputLog.Track].FriendlyName;

            return result;

        }

        private Result ProcessRace(OutputLog outputLog)
        {
            // TODO: Implement
            return null;
        }

        public IEnumerable<SessionObjective> EvaluateSessionResult(SessionData sessionData, OutputLog result)
        {
            // Session objectives
            foreach (var objective in sessionData.SessionObjectives)
            {
                //var objectiveResult = objective.Evaluate(sessionData, result);
            }
            return null;
            // Event objectives

        }


     
    }
}
