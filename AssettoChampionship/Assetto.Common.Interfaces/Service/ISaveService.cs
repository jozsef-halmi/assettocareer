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
        SavedSeason SaveResult(string seasonId, string eventId, string sessionId, Result result);

        Result LoadResult(string seasonId, string eventId, string sessionId);

        SavedSeason GetSavedSeason(string seasonId);
    }
}
