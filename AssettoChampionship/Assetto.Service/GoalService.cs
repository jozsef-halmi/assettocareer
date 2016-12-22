using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Interfaces.Manager;
using Assetto.Common.Interfaces.Service;
using Assetto.Common.Objectives;
using Assetto.Common.ProcessedResult;

namespace Assetto.Service
{
    public class GoalService : IGoalService
    {
        public ISaveService SaveService { get; set; }

        public ISeriesService SeriesService { get; set; }
        public GoalService(ISaveService saveService
            , ISeriesService seriesService)
        {
            this.SaveService = saveService;
            this.SeriesService = seriesService;
        }

        public int GetAchievedGoalsCount(string seriesId, string eventId, string sessionId, Result result)
        {
            var goalCount = 0;
            if (result != null)
            {
                foreach (var objective in GetSessionGoals(seriesId, eventId, sessionId))
                {
                    goalCount =  objective.Evaluate(result) ? ++goalCount : goalCount;
                }
            }

            return goalCount;
        }

        public List<SessionObjective> GetSessionGoals(string seriesId, string eventId, string sessionId)
        {
            return SeriesService.GetSession(seriesId, eventId, sessionId).PrimarySessionObjectives;
        }
    }
}
