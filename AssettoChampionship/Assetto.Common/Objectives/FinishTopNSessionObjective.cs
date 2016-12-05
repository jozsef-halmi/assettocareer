using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Output;

namespace Assetto.Common.Objectives
{
    public class FinishTopNSessionObjective : SessionObjective
    {
        public int N { get; set; }

        public override bool Evaluate(SessionData sessionData, EventResult result)
        {
            // TODO
            return false;
        }
    }
}
