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
            switch (result.SessionType)
            {
                case SessionType.Practice:
                    return this.EvaluatePractice(result);
                case SessionType.Qualifying:
                    return this.EvaluateQualify(result);
                case SessionType.Race:
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
