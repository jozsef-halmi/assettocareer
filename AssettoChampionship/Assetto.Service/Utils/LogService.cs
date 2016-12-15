using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Interfaces.Service;
using log4net;

namespace Assetto.Service
{
    public class LogService : ILogService
    {
        private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public void Log(string text)
        {
            Log4Net.Info(text);
        }
    }
}
