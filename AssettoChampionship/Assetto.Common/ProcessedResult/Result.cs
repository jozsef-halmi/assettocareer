using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Enum;

namespace Assetto.Common.ProcessedResult
{
    public class Result
    {
        public string Track { get; set; }

        public int Duration { get; set; }

        public int LapCount { get; set; }

        //public string Layout { get; set; }

        public string Name { get; set; }

        public string FriendlyName { get; set; }

        public EventType EventType { get; set; }

        public IEnumerable<ResultPlayer> QualificationResult { get; set; }

        public IEnumerable<ResultPlayer> RaceResult { get; set; }



    }
}
