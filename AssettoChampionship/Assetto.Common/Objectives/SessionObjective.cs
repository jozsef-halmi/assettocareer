using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Enum;
using Assetto.Common.Output;
using Assetto.Common.ProcessedResult;

namespace Assetto.Common.Objectives
{
    public abstract class SessionObjective
    {
        public bool IsSuccess  { get; set; }

        public bool Evaluate(Result result)
        {
            switch (result.EventType)
            {
                case EventType.Practice:
                    return this.EvaluatePractice(result);
                case EventType.Qualifying:
                    return this.EvaluateQualify(result);
                case EventType.Race:
                    return this.EvaluateRace(result);
                default:
                    throw new Exception("Invalid eventtype");
            }
        }

        protected abstract bool EvaluatePractice(Result result);
        protected abstract bool EvaluateQualify(Result result);
        protected abstract bool EvaluateRace(Result result);

    }
}
