using Assetto.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Interfaces.Service
{
    public interface IProcessService
    {
        void StartProcess(string path);

        void MonitorProcess(string exe
             , ProcessInfo.StartedEventHandler startHandler
             , ProcessInfo.TerminatedEventHandler terminateHandler);
    }
}
