using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.ProcessedResult;

namespace Assetto.Common.DTO
{
    public class ConfiguredSessionDTO
    {
        public EventData EventData { get; set; }
        public SessionData SessionData { get; set; }
        public Result PreviousSessionResult { get; set; }

        public List<OpponentData> OrderedGrid { get; set; }
    }
}
