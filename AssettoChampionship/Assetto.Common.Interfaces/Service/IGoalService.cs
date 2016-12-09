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
        //int GetAchievedGoalsCount(Guid seriesId);
        //int GetAchievedGoalsCount(Guid seriesId, Guid eventId);

        int GetAchievedGoalsCount(Guid seriesId, Guid eventId, Guid sessionId, Result result);

        List<SessionObjective> GetSessionGoals(Guid seriesId, Guid eventId, Guid sessionId);

    }
}
