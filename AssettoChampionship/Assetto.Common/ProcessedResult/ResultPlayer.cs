using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.ProcessedResult
{
    public class ResultPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BestLap
        {
            get
            {
                if (this.Laps == null || this.Laps.Count() < 1)
                {
                    return 0;
                }
                else
                {
                    return this.Laps.OrderBy(l => l.Time).First().Time;
                }
            }
        }
        public int LapCount { get; set; }

        public List<ResultLap> Laps { get; set; }


    }
}
