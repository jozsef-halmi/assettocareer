using Assetto.Common.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Objectives;
using Assetto.Common.ProcessedResult;

namespace Assetto.Common.Interfaces.Service
{
    public interface IResultService
    {
        Result GetResultForLog(string contents);

        Result ProcessResult(OutputLog outputLog);

        void EvaluateSessionResult(Result result);
    }
}
