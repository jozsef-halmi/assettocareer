using Assetto.Common.Interfaces.Service;
using Assetto.Common.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Service.Utils
{
    public class ProcessService : IProcessService
    {
        public void StartProcess(string processPath)
        {
            //var myProcess = new Process { StartInfo = new ProcessStartInfo(processPath) };
            //myProcess.Start();
            //myProcess.WaitForExit();

            ProcessStartInfo startInfo = new ProcessStartInfo() {
                FileName = processPath
            };
            Process process = Process.Start(startInfo);
            process.EnableRaisingEvents = true;
            process.Exited += Process_Exited;
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            // TODO
        }

        public void MonitorProcess(string exe
            , ProcessInfo.StartedEventHandler startHandler
            , ProcessInfo.TerminatedEventHandler terminateHandler)
        {
            var process = new ProcessInfo(exe);

            process.Started += startHandler;
            process.Terminated += terminateHandler;
            
        }
    }
}
