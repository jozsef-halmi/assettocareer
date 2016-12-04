using Assetto.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Output
{
    public class SessionResult
    {
        public int Event { get; set; }

        public string Name { get; set; }

        public EventType Type { get; set; }

        public int LapsCount { get; set; }

        public int Duration { get; set; }

        public IEnumerable<ResultLap> Laps { get; set; }

        public IEnumerable<int> LapsTotal { get; set; }

        public IEnumerable<ResultLap> BestLaps { get; set; }

        // TODO: Extras
    }
}
