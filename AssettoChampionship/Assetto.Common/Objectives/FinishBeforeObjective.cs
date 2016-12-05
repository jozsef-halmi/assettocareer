using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Output;

namespace Assetto.Common.Objectives
{
    public class FinishBeforeObjective : SessionObjective
    {
        public string Name { get; set; }

        public override bool Evaluate(SessionData sessionData, OutputLog result)
        {
            // TODO
            return false;
        }
    }
}
