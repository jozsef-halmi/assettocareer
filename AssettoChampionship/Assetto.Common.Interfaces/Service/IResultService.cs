using Assetto.Common.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Objectives;

namespace Assetto.Common.Interfaces.Service
{
    public interface IResultService
    {
        OutputLog GetResult(string contents);

        IEnumerable<SessionObjective> EvaluateSessionResult(SessionData sessionData, OutputLog result);
    }
}
