using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.ProcessedResult
{
    public class ResultLap
    {
        public List<int> Sectors { get; set; }

        public int Time { get; set; }

        public int LapId { get; set; }
    }
}
