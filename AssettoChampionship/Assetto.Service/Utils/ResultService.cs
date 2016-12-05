using Assetto.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Enum;
using Assetto.Common.Objectives;
using Assetto.Common.Output;
using Newtonsoft.Json;

namespace Assetto.Service.Utils
{
    public class ResultService : IResultService
    {
        public EventResult GetResult(string contents)
        {
            return JsonConvert.DeserializeObject<EventResult>(contents);
        }

        public IEnumerable<SessionObjective> EvaluateSessionResult(SessionData sessionData, EventResult result)
        {
            // Session objectives
            foreach (var objective in sessionData.SessionObjectives)
            {
                var objectiveResult = objective.Evaluate(sessionData, result);
            }
            return null;
            // Event objectives

        }


     
    }
}
