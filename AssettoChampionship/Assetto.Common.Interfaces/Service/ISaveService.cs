using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.ProcessedResult;
using Assetto.Common.SaveGames;

namespace Assetto.Common.Interfaces.Service
{
    public interface ISaveService
    {
        SavedSeason SaveResult(Guid seasonId, Guid eventId, Guid sessionId, Result result);

        Result LoadResult(Guid seasonId, Guid eventId, Guid sessionId);
    }
}
