using Assetto.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Output
{
    public class OutputSession
    {
        public int Event { get; set; }

        public string Name { get; set; }

        public EventType Type { get; set; }

        public int LapsCount { get; set; }

        public int Duration { get; set; }

        public List<OutputLap> Laps { get; set; }

        public List<int> LapsTotal { get; set; }

        public List<OutputLap> BestLaps { get; set; }

        public List<int> RaceResult { get; set; }

        // TODO: Extras
    }
}
