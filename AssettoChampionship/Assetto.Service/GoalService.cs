using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Interfaces.Manager;
using Assetto.Common.Interfaces.Service;
using Assetto.Common.Objectives;

namespace Assetto.Service
{
    public class GoalService : IGoalService
    {
        public ISaveService SaveService { get; set; }
        public ISeriesManager SeriesManager { get; set; }

        public GoalService(ISaveService saveService
            , ISeriesManager seriesManager)
        {
            this.SaveService = saveService;
            this.SeriesManager = seriesManager;
        }

        public int GetAchievedGoalsCount(Guid seriesId, Guid eventId, Guid sessionId)
        {
            var goalCount = 0;
            var result = this.SaveService.LoadResult(seriesId, eventId, sessionId);
            if (result != null)
            {
                foreach (var objective in GetSessionGoals(seriesId, eventId, sessionId))
                {
                    goalCount =  objective.Evaluate(result) ? ++goalCount : goalCount;
                }
            }

            return goalCount;
        }

        public List<SessionObjective> GetSessionGoals(Guid seriesId, Guid eventId, Guid sessionId)
        {
            return SeriesManager.GetSession(seriesId, eventId, sessionId).Objectives;
        }
    }
}
