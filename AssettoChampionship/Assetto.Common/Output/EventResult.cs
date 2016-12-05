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

        public IEnumerable<OutputPlayer> Players { get; set; }

        public IEnumerable<OutputSession> Sessions { get; set; }

    }
}
