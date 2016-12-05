using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Output;
using Assetto.Common.ProcessedResult;

namespace Assetto.Common.Objectives
{
    public class FinishBeforeObjective : SessionObjective
    {
        public string Name { get; set; }


        protected override bool EvaluatePractice(Result result)
        {
            throw new NotImplementedException();
        }

        protected override bool EvaluateQualify(Result result)
        {
            throw new NotImplementedException();
        }

        protected override bool EvaluateRace(Result result)
        {
            throw new NotImplementedException();
        }
    }
}
