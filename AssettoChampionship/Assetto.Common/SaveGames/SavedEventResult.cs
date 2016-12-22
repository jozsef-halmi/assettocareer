using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.ProcessedResult;

namespace Assetto.Common.SaveGames
{
    public class SavedEventResult
    {
        public string EventId { get; set; }
        public Dictionary<string, Result> SessionResult { get; set; }
    }
}
