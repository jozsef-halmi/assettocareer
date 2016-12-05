using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Output
{
    public class OutputLog
    {
        public string Track { get; set; }

        public int Number_of_sessions { get; set; }

        public List<OutputPlayer> Players { get; set; }

        public List<OutputSession> Sessions { get; set; }

    }
}
