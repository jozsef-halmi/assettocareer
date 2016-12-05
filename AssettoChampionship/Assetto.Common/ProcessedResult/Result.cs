using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Enum;
using Assetto.Common.Objectives;

namespace Assetto.Common.ProcessedResult
{
    public class Result
    {
        public Guid Id { get; set; }

        public string Track { get; set; }

        public int Duration { get; set; }

        public int LapCount { get; set; }

        //public string Layout { get; set; }

        public string Name { get; set; }

        public string FriendlyName { get; set; }

        public SessionType SessionType { get; set; }

        // EventType chooses these
        public List<ResultPlayer> QualificationResult { get; set; }

        public List<ResultPlayer> RaceResult { get; set; }

        public List<SessionObjective> PrimaryObjectives { get; set; }

        public List<SessionObjective> SecondaryObjectives { get; set; }




    }
}
