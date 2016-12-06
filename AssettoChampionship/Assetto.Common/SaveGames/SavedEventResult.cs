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
        public Guid EventId { get; set; }
        public Dictionary<Guid, Result> SessionResult { get; set; }
    }
}
