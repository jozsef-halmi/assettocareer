using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Output
{
    public class EventResult
    {
        public string Track { get; set; }

        public int Number_of_sessions { get; set; }

        public IEnumerable<ResultPlayer> Players { get; set; }

        public IEnumerable<SessionResult> Sessions { get; set; }

    }
}
