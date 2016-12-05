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
        public OutputLog GetResult(string contents)
        {
            return JsonConvert.DeserializeObject<OutputLog>(contents);
        }

        public IEnumerable<SessionObjective> EvaluateSessionResult(SessionData sessionData, OutputLog result)
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
