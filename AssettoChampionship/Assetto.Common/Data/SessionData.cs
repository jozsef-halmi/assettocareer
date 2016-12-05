using Assetto.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Objectives;

namespace Assetto.Common.Data
{
    public class SessionData
    {
        public Guid Id { get; set; }

        public EventType EventType { get; set; }

        // For practice, and qual
        public int? Duration { get; set; }

        // For race
        public int? Laps { get; set; }
        public int? StartingPosition { get; set; }

        public IEnumerable<Objective> SessionObjectives { get; set; }


    }
}
