using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Objectives;
using Assetto.Common.ProcessedResult;

namespace Assetto.Common.Interfaces.Service
{
    public interface IGoalService
    {
        //int GetAchievedGoalsCount(string seriesId);
        //int GetAchievedGoalsCount(string seriesId, string eventId);

        int GetAchievedGoalsCount(string seriesId, string eventId, string sessionId, Result result);

        List<SessionObjective> GetSessionGoals(string seriesId, string eventId, string sessionId);

    }
}
