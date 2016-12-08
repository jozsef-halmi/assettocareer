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

        public SessionType SessionType { get; set; }

        // For practice, and qual
        public int? Duration { get; set; }

        // For race
        public int? Laps { get; set; }
        public int? StartingPosition { get; set; }

        public List<OpponentData> OrderedGrid { get; set; }

        //public List<OpponentData> Opponents { get; set; }

        public IEnumerable<SessionObjective> PrimarySessionObjectives { get; set; }

        public IEnumerable<SessionObjective> SecondarySessionObjectives { get; set; }



    }
}
