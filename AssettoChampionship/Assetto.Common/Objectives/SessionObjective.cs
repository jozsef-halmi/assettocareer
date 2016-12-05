using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Enum;
using Assetto.Common.Output;

namespace Assetto.Common.Objectives
{
    public abstract class SessionObjective
    {
        public bool IsSuccess  { get; set; }

        public abstract bool Evaluate(SessionData sessionData, OutputLog result);
    }
}
